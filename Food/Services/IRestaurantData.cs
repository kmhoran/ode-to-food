using Food.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> Get();
        Restaurant Get(int id);
    }
}
