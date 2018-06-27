using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Food.Pages
{
    public class GreetingModel : PageModel
    {
        private IGreeter _greeter;

        public string CurrentGreeting { get; set; }
        public string Name { get; set; }

        public GreetingModel(IGreeter greeter)
        {
            _greeter = greeter;
        }

        // OnGet establishes all the resources that will be provided to the Razor page
        // URL parameters are collected here
        public void OnGet(string name)
        {
            CurrentGreeting = this._greeter.GetMessage();
            Name = name;
        }
    }
}