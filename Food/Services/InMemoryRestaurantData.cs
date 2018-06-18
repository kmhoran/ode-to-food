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
                new Restaurant{ RestaurantId=1, Name="Chez Mon Vieux", Price=PriceType.Affordable},
                new Restaurant{ RestaurantId=2, Name="Le Président", Price=PriceType.Expensive },
                new Restaurant{ RestaurantId=3, Name="Au Bureau", Price=PriceType.Cheap }
            };
        }

        public IEnumerable<Restaurant> Get()
        {
            return _restos.OrderBy(r => r.Name);
        }

        public Restaurant Get(int id)
        {
            return _restos.SingleOrDefault(r => r.RestaurantId == id);
        }
    }
}
