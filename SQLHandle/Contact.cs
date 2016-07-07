using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQLHandler
{
    public class Contact
    {
        public Contact(string firstName, string lastName, string id)
        {
            FirstName = firstName;
            LastName = lastName;
            ID = id;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ID { get; set; }

    }
}