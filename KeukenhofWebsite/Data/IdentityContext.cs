using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeukenhofWebsite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;

namespace KeukenhofWebsite.Data
{
    public class IdentityContext :IdentityDbContext<Administrator, AppRole, int>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {

        }
    }
}
