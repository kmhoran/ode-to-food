using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food.Services
{
    public class Greeter : IGreeter
    {
        private IConfiguration _config;

        public Greeter(IConfiguration configuration)
        {
            _config = configuration;
        }

        public string GetMessage()
        {
            return String.Concat("Interface says Hi and ", _config["Greeting"]);
        }
    }
}
