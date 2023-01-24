using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.web.Controllers
{
    public class RestaurantsController : Controller
    {

        IRestaurantData dataBase;

        public RestaurantsController(IRestaurantData database)
        {
            this.dataBase = database;
        }
        // GET: Restaurants
        public ActionResult Index()
        {
            var model = dataBase.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = dataBase.Get(id);

            if (model == null)
            {
                return View("NotFound");
            }
            return View(model); 
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (String.IsNullOrEmpty(restaurant.Name))
            {
                ModelState.AddModelError(nameof(restaurant.Name), "The name is required"); 
            }
            if (ModelState.IsValid)
            {
                dataBase.Add(restaurant);
                return RedirectToAction("Details", new {restaurant.Id});
            }
            return View();
        }

        public ActionResult Edit(int id) 
        {
            var model = dataBase.Get(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
           
            if (ModelState.IsValid)
            {
                dataBase.Update(restaurant);
                TempData["Message"] = "You have successfully edited the restaurant!"; 
                return RedirectToAction("Details", new { id = restaurant.Id } );
            }
            return View("NotFound");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = dataBase.Get(id); 
            if(model == null) 
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete (Restaurant restaurant) 
        {
            dataBase.Delete(restaurant);
            return RedirectToAction("Index");
        }

    }
}