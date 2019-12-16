using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Models
{
    class User
    {
        public string LastName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string BirthDay { get; set; }
        public string DocumentNumber { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }

        public User(string lastname, string name, string middlename, string birthday
            ,string document, string mail, string phone)
        {
            LastName = lastname;
            Name = name;
            MiddleName = middlename;
            BirthDay = birthday;
            DocumentNumber = document;
            Mail = mail;
            Phone = phone;
        }
    }
}
