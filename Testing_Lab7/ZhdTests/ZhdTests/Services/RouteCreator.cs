using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhdTests.Model;

namespace ZhdTests.Services
{
    class RouteCreator
    {
        
        public static string departureCity="Москва";

        public static string arrivalCity="Казань";
        public static Route WithAllProperties()
        {
            return new Route(departureCity, arrivalCity);
        }
    }
}
