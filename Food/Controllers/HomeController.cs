using Food.Models;
using Food.Services;
using Food.ViewModels;
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
        private IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData,
                              IGreeter greeter)
        {
            _restoData = restaurantData;
            _greeter = greeter;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel()
            {
                Restaurants = _restoData.Get(),
                CurrentMessage = _greeter.GetMessage()
            };

            return View(model);
        }


        public IActionResult Details(int id)
        {
            Restaurant model = _restoData.Get(id);
            if(model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditModel editModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var newResto = new Restaurant()
            {
                RestaurantId = 0,
                Name = editModel.Name,
                Price = editModel.Price
            };

            int newId =_restoData.Add(newResto);

            return RedirectToAction(nameof(Details), new { id=newId});
        }

        public IActionResult RestaurantApi()
        {
            IEnumerable<Restaurant> model = _restoData.Get();

            return new ObjectResult(model);
        }
    }
}
