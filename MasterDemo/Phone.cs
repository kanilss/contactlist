using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterDemo
{
    public class Phone
    {
        public Phone(string phoneNumber, string type)
        {
            PhoneNumber = phoneNumber;
            Type = type;
        }
        public string PhoneNumber { get; set; }
        public string Type { get; set; }
    }
}