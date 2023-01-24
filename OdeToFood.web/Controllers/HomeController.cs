using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.web.Controllers
{
    public class HomeController : Controller
    {
        IRestaurantData dataBase;

        public HomeController(IRestaurantData database)
        {
            this.dataBase = database;
        }


        public ActionResult Index()
        {
            var model = dataBase.GetAll(); 
            return View(model);
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
        }
    }
}