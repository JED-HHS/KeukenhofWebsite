using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeukenhofWebsite.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
