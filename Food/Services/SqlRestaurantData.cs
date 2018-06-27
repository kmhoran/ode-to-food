using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.Data;
using Food.Models;
using Microsoft.EntityFrameworkCore;

namespace Food.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private FoodDbContext _dbContext;

        public SqlRestaurantData(FoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(Restaurant restaurant)
        {
            _dbContext.Restaurants.Add(restaurant);
            _dbContext.SaveChanges();
            return restaurant.RestaurantId;
        }

        public IEnumerable<Restaurant> Get()
        {
            return _dbContext.Restaurants.OrderBy(r => r.Name);
        }

        public Restaurant Get(int id)
        {
            return _dbContext.Restaurants.FirstOrDefault(r => r.RestaurantId == id);
        }

        public Restaurant Update(Restaurant restaurant)
        {
            _dbContext.Attach(restaurant).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return restaurant;
        }
    }
}
