using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OdeToFood.web.API
{
    public class RestaurantsController : ApiController
    {
        private readonly IRestaurantData restaurnatData;

        public RestaurantsController(IRestaurantData restaurantData)
        {
            this.restaurnatData = restaurantData;
        }

        public IEnumerable<Restaurant> Get() 
        {
            var model = restaurnatData.GetAll();
            return model; 
        }

    }
}
