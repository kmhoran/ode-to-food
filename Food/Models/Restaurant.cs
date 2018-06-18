using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public PriceType Price { get; set; }
    }
}
