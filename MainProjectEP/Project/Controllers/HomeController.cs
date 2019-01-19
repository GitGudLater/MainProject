using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using BL;
using DishClassLibrary.temp.test;
using System.ComponentModel.DataAnnotations;

namespace Project.Controllers
{
    public class HomeController : Controller
    {

        BLclass bis_log = new BLclass();
        // GET: Database

        [Authorize(Roles = "admin")]
        public ActionResult Adminpage()
        {
            return View();
        }

        public ActionResult Mainpage()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        [Authorize(Roles = "editor")]
        public ActionResult GetTypes()
        {
            return View(bis_log.GetTypes());
        }

        [HttpGet]
        //[Authorize(Roles = "admin")]
        //[Authorize(Roles = "editor")]
        public ActionResult SetBook()
        {
            Set_Books book = new Set_Books();
            return View(book);
        }

        [HttpPost]
        //[Authorize(Roles = "admin")]
        //[Authorize(Roles = "editor")]
        public ActionResult SetBook(Set_Books book)
        {
            bis_log.SetBooks(book);
            return RedirectToAction("Mainpage");
        }

        [HttpGet]
        //[Authorize(Roles = "admin")]
        //[Authorize(Roles = "editor")]
        public ActionResult SetType()
        {
            Get_or_Set_types type = new Get_or_Set_types();
            return View(type);
        }

        [HttpPost]
        //[Authorize(Roles = "admin")]
        //[Authorize(Roles = "editor")]
        public ActionResult SetType(Get_or_Set_types type)
        {
            bis_log.SetType(type);
            return RedirectToAction("Mainpage");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        [Authorize(Roles = "editor")]
        public ActionResult EditDish(int id)
        {
            Set_Dish dish = bis_log.GetSingleDish(id);
            return View(dish);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [Authorize(Roles = "editor")]
        public ActionResult EditDish(Set_Dish dish)
        {
            bis_log.UpdateDish(dish);
            return RedirectToAction("GetDishes");
        }

        [HttpGet]
        //[Authorize(Roles = "admin")]
        //[Authorize(Roles = "editor")]
        public ActionResult SetDish()
        {
            Set_Dish dish = new Set_Dish();
            return View(dish);
        }

        [HttpPost]
        //[Authorize(Roles = "admin")]
        //[Authorize(Roles = "editor")]
        public ActionResult SetDish(Set_Dish dish, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
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
        [Authorize(Roles = "admin")]
        [Authorize(Roles = "editor")]
        public ActionResult DeleteDish(int id)
        {
            bis_log.DeleteDish(id);
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [Authorize(Roles = "editor")]
        public ActionResult DeleteDish()
        {
            return RedirectToAction("GetDishes");
        }

        [HttpGet]
        public ActionResult GetDishes()
        {
            return View(bis_log.GetDishesWithTypesList());
        }

        [HttpGet]
        public ActionResult GetIngrWithDishes(int id)
        {
            return View(bis_log.GetRelations(id));
        }

        [HttpGet]
        public ActionResult GetIngredients()
        {
            return View(bis_log.GetIngredients());
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        [Authorize(Roles = "editor")]
        public ActionResult SetIngredient()
        {
            Set_Ingredients ingredient = new Set_Ingredients();
            return View(ingredient);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [Authorize(Roles = "editor")]
        public ActionResult SetIngredient(Set_Ingredients ingredient)
        {
            bis_log.SetIngredient(ingredient);
            return RedirectToAction("GetIngredietns");
        }

        /*public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }*/
    }
}