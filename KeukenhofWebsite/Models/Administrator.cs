﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace KeukenhofWebsite.Models
{
    public class Administrator : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
