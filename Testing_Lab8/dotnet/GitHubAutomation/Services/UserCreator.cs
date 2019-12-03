using GitHubAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Services
{
    class UserCreator
    {
        public static User WithAllProperties()
        {
            return new User(TestDataReader.GetData("LastName"), TestDataReader.GetData("Name"), TestDataReader.GetData("MiddleName")
                ,TestDataReader.GetData("BirthDay"), TestDataReader.GetData("Document"), TestDataReader.GetData("Mail"), TestDataReader.GetData("Phone"));
        }
        public static User WithFailDocument()
        {
            return new User(TestDataReader.GetData("LastName"), TestDataReader.GetData("Name"), TestDataReader.GetData("MiddleName")
                , TestDataReader.GetData("BirthDay"), "0000000000", TestDataReader.GetData("Mail"), TestDataReader.GetData("Phone"));
        }
    }
}
