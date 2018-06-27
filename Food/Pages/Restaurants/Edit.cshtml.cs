using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.Models;
using Food.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Food.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private IRestaurantData _restoData;


        /* Brind Property allows POST actions to be bound to the class propery; two-way binding */
        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public EditModel(IRestaurantData restoData)
        {
            _restoData = restoData;
        }

        public IActionResult OnGet(int id)
        {
            Restaurant = _restoData.Get(id);
            if (Restaurant == null)
            {
                return RedirectToAction("Index", "Home");
            }
            // Equivalent to return View()
            return Page();
        }


        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _restoData.Update(Restaurant);
                return RedirectToAction("Details", "Home", new { id = Restaurant.RestaurantId });
            }
            else
            {
                return Page();
            }
        }
    }
}