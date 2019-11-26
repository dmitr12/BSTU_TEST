using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Models
{
    class Route
    {
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }

        public Route(string departureCity, string arrivalCity)
        {
            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;
        }
    }
}
