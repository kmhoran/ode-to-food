using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food.Controllers
{
    // Attribute routing will overwrite default routing

    [Route("company/[controller]")]
    public class AboutController
    {
        [Route("")]
        public string Phone()
        {
            return "867-5309";
        }

        // when attribute routes are used on one method, they ought to be used on all methods
        [Route("[action]")]
        public string Address()
        {
            return "2265 E. El Segundi Blvd";
        }
    }
}
