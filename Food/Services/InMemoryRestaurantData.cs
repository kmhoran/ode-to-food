using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.Models;

namespace Food.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> _restos;


        public InMemoryRestaurantData()
        {
            _restos = new List<Restaurant>()
            {
                new Restaurant{ RestaurantId=1, Name="Resto 1"},
                new Restaurant{ RestaurantId=2, Name="Resto 2" },
                new Restaurant{ RestaurantId=3, Name="Resto 3" }
            };
        }

        public IEnumerable<Restaurant> Get()
        {
            return _restos.OrderBy(r => r.Name);
        }
    }
}
