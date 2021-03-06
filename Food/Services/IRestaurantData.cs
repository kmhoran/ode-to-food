﻿using Food.Models;
using Food.ViewModels;
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
        int Add(Restaurant restaurant);
        Restaurant Update(Restaurant restaurant);
    }
}
