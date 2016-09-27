using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerWeb.Models
{
    public class CustomerOrder
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OrderItem { get; set; }
    }
}