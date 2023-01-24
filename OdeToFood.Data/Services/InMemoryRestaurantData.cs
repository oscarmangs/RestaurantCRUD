using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "scott's Pizza", Cuisine = CuisineType.Italian},
                new Restaurant {Id = 2, Name = "Tersiguels", Cuisine = CuisineType.French},
                new Restaurant {Id = 3, Name = "Mango Grove", Cuisine = CuisineType.Indian },
                new Restaurant {Id = 4, Name = "La Neta", Cuisine = CuisineType.Mexican }
            };
        }

        public void Add(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            restaurant.Id = restaurants.Max(r => r.Id);

        }

      

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }

        public void Update(Restaurant restaurant)
        {
            var oldRestaurant = Get(restaurant.Id); 
            oldRestaurant.Name = restaurant.Name;   
            oldRestaurant.Cuisine = restaurant.Cuisine; 
        }
    }
}

