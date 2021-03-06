using System;
using System.Collections.Generic;
using System.Text;

namespace MMT.CustomerOrder.Core.User
{
  public class User
    {
        public string Email { get; set; }
        public string CustomerId { get; set; }
        public bool Website { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LastLoggedIn { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string Postcode { get; set; }
        public string PreferredLanguage { get; set; }


    }
}
