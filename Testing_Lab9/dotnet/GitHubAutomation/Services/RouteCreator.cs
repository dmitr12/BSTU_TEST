using Framework.Models;
using GitHubAutomation.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Services
{
    class RouteCreator
    {
        public static Route WithAllProperties()
        {
            return new Route(TestDataReader.GetData("DepartureCity").Value, TestDataReader.GetData("ArrivalCity").Value, DateTime.Now.AddDays(1).ToString("dd.MM.yyyy"));
        }

        public static Route WithEqualCities()
        {
            return new Route(TestDataReader.GetData("DepartureCity").Value, TestDataReader.GetData("DepartureCity").Value, DateTime.Now.AddDays(1).ToString("dd.MM.yyyy"));
        }

        public static Route WithFailDate()
        {
            return new Route(TestDataReader.GetData("DepartureCity").Value, TestDataReader.GetData("ArrivalCity").Value, DateTime.Now.AddDays(-1).ToString("dd.MM.yyyy"));
        }

        public static Route WithoutDate()
        {
            return new Route(TestDataReader.GetData("DepartureCity").Value, TestDataReader.GetData("ArrivalCity").Value, string.Empty);
        }
    }
}
