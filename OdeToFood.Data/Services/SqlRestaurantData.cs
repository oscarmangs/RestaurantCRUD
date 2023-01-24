using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDBContext database;

        public SqlRestaurantData(OdeToFoodDBContext database)
        {
            this.database = database;
        }


        public void Add(Restaurant restaurant)
        {
            database.Restaurants.Add(restaurant);
            database.SaveChanges();

        }

        public void Delete(Restaurant restaurant)
        {
            var entry = database.Entry(restaurant);
            entry.State = EntityState.Deleted;
            database.SaveChanges(); 
        }

        public Restaurant Get(int id)
        {
            return database.Restaurants.FirstOrDefault(r => r.Id == id); 
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in database.Restaurants
                   orderby r.Name
                   select r; 
        }

        public void Update(Restaurant restaurant)
        {
            var entry = database.Entry(restaurant);
            entry.State = EntityState.Modified;
            database.SaveChanges(); 
        }
    }
}
