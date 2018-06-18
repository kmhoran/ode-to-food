using Food.Models;
using Food.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restoData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restoData = restaurantData;
        }
        public IActionResult Index()
        {
            IEnumerable<Restaurant> model = _restoData.Get();

            return View(model);
        }


        public IActionResult RestaurantApi()
        {
            IEnumerable<Restaurant> model = _restoData.Get();

            return new ObjectResult(model);
        }
    }
}
