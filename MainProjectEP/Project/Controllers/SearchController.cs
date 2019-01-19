using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;
using DishClassLibrary.temp.test;

namespace Project.Controllers
{
    public class SearchController : Controller
    {
        BLclass bis_log = new BLclass();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string name, string value)
        {
            if (value == "" || value == null || name == null || name == "")
            {
                return RedirectToAction("Index");
            }

            if (name == "DishName")
            {
                return RedirectToAction("DishNameSearch", value);
            }

            if (name == "Type")
            {
                return RedirectToAction("TypeNameSearch", value);
            }

            if (name == "Ingredient")
            {
                return RedirectToAction("IngredientNameSearch", value);
            }

            return RedirectToAction("Index");
        }

        public ActionResult DishNameSearch(string value)
        {
            return View(bis_log.GetDishesByName(value));
        }

        public ActionResult TypeNameSearch(string value)
        {
            return View(bis_log.GetDishesByTypes(value));
        }

        public ActionResult IngredientNameSearch(string value)
        {
            return View(bis_log.GetIngredientsByName(value));
        }
    }
}