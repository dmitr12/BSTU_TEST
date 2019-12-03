using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Models
{
    class Route
    {
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        //public DateTime DepartureDate { get; set; }

        public Route(string departureCity, string arrivalCity/*DateTime departureDate*/)
        {
            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;
            //DepartureDate = departureDate;
        }
    }
}
