using Food.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food.ViewComponents
{
    /* 
    * View Components are classes that render Razor Views 
    * 
    * It is important to suffix thas class name with "ViewComponent" 
    * as this is how dotNet will be able to identify this as a VC
    * 
    * Views for components are kept in ~/Views/Shared/Components/[ViewComponentName]/[ViewFile].cshtml
    */
    
    public class GreeterViewComponent: ViewComponent
    {
        private IGreeter _greeter;

        public GreeterViewComponent(IGreeter greeter)
        {
            _greeter = greeter;
        }

        // This is the one render method MVC will invoke 
        public IViewComponentResult Invoke()
        {
            string message = _greeter.GetMessage();
            string model = String.Format("View Component Says '{0}'", message);
            // When we pass view a simple string type as our model, we must first pass the
            // name of the viewFile. Otherwise MVC will try to find a file with the name of
            // our model.
            return View("Default", model);
        }
    }
}
