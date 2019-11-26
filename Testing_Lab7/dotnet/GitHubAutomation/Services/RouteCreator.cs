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
            return new Route(TestDataReader.GetData("DepartureCity"), TestDataReader.GetData("ArrivalCity"));
        }
    }
}
