using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using BL;
using DishClassLibrary.temp.test;

namespace MainProject.Controllers
{
    public class DatabaseController : Controller
    {
        BLclass bis_log = new BLclass();
        // GET: Database
        public ActionResult Mainpage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SetBook()
        {
            Set_Books book = new Set_Books();
            return View(book);
        }

        [HttpPost]
        public ActionResult SetBook(Set_Books book)
        {
            bis_log.SetBooks(book);
            return RedirectToAction("Mainpage");
        }

        [HttpGet]
        public ActionResult SetType()
        {
            Get_or_Set_types type = new Get_or_Set_types();
            return View(type);
        }

        [HttpPost]
        public ActionResult SetType(Get_or_Set_types type)
        {
            bis_log.SetType(type);
            return RedirectToAction("Mainpage");
        }

        [HttpGet]
        public ActionResult SetDish()
        {
            var dish = new Set_Dish();
            return View(dish);
        }

        [HttpPost]
        public ActionResult SetDish(Set_Dish dish,HttpPostedFileBase file)
        {
            if(file!=null && file.ContentLength>0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Temp/"), fileName);
                file.SaveAs(path);

                FileStream fs = new FileStream(path, FileMode.Open);

                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);

                dish.Example = new byte[buffer.Length];
                dish.Example = buffer;
                fs.Close();

            }
            else
            {
                dish.Example = new byte[1];
                dish.Example[0] = 0;
            }

            bis_log.SetDish(dish);

            foreach (var filepath in System.IO.Directory.GetFiles(Server.MapPath("~") + "/Content/Temp"))
            {
                System.IO.File.Delete(filepath);
            }

            return RedirectToAction("Mainpage");
        }

        [HttpGet]
        public ActionResult GetDishes()
        {
            return View(bis_log.GetDishesWithTypesList());
        }
    }
}