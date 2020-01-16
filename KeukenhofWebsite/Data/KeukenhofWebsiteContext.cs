using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KeukenhofWebsite.Models;

namespace KeukenhofWebsite.Models
{
    public class KeukenhofWebsiteContext : DbContext
    {
        public KeukenhofWebsiteContext (DbContextOptions<KeukenhofWebsiteContext> options)
            : base(options)
        {
        }

        public DbSet<QenA> QenA { get; set; }
        public DbSet<Content> Content { get; set; }
        public DbSet<Park> Park { get; set; }
        public DbSet<KeukenhofWebsite.Models.Admin> Admin { get; set; }
    }
}
