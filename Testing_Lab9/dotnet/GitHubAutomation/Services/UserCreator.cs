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
            return new User(TestDataReader.GetData("LastName").Value, TestDataReader.GetData("Name").Value, TestDataReader.GetData("MiddleName").Value
                ,TestDataReader.GetData("BirthDay").Value, TestDataReader.GetData("Document").Value, TestDataReader.GetData("Mail").Value, TestDataReader.GetData("Phone").Value);
        }
        public static User WithFailDocument()
        {
            return new User(TestDataReader.GetData("LastName").Value, TestDataReader.GetData("Name").Value, TestDataReader.GetData("MiddleName").Value
                , TestDataReader.GetData("BirthDay").Value, "0000000000", TestDataReader.GetData("Mail").Value, TestDataReader.GetData("Phone").Value);
        }

        public static User WithFailBirthDay()
        {
            return new User(TestDataReader.GetData("LastName").Value, TestDataReader.GetData("Name").Value, TestDataReader.GetData("MiddleName").Value
                , "12.12.2222", TestDataReader.GetData("Document").Value, TestDataReader.GetData("Mail").Value, TestDataReader.GetData("Phone").Value);
        }
    }
}
