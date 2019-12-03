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
            return new Route(TestDataReader.GetData("DepartureCity"), TestDataReader.GetData("ArrivalCity"), DateTime.Now.AddDays(1).ToString("dd.MM.yyyy"));
        }

        public static Route WithEqualCities()
        {
            return new Route(TestDataReader.GetData("DepartureCity"), TestDataReader.GetData("DepartureCity"), DateTime.Now.AddDays(1).ToString("dd.MM.yyyy"));
        }

        public static Route WithFailDate()
        {
            return new Route(TestDataReader.GetData("DepartureCity"), TestDataReader.GetData("ArrivalCity"), DateTime.Now.AddDays(-1).ToString("dd.MM.yyyy"));
        }

        public static Route WithoutDate()
        {
            return new Route(TestDataReader.GetData("DepartureCity"), TestDataReader.GetData("ArrivalCity"), string.Empty);
        }
    }
}
