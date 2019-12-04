using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Merchbooth.Classes
{
    public class UserDetails
    {
        public int UserKey { get; set; }
        public bool isValidUser { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }

        public bool IsSystemAdmin { get; set; }
        public bool IsBand { get; set; }
    }
}