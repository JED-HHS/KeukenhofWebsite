using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KeukenhofWebsite.Models
{
    public class KeukenhofWebsiteContext : DbContext
    {
        public KeukenhofWebsiteContext (DbContextOptions<KeukenhofWebsiteContext> options)
            : base(options)
        {
        }

        public DbSet<KeukenhofWebsite.Models.test> test { get; set; }
    }
}
