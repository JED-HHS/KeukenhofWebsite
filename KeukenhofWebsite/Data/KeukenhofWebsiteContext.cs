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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ZoektermAction>().HasKey(sc => new {sc.ZoektermId, sc.ActionId});

            modelBuilder.Entity<ZoektermAction>()
                .HasOne<Zoekterm>(sc => sc.Zoekterm)
                .WithMany(s => s.ZoektermActions)
                .HasForeignKey(sc => sc.ZoektermId);

            modelBuilder.Entity<ZoektermAction>()
                .HasOne<Action>(sc => sc.Action)
                .WithMany(s => s.ZoektermActions)
                .HasForeignKey(sc => sc.ActionId);
        }

        public DbSet<QenA> QenA { get; set; }
        public DbSet<Content> Content { get; set; }
        public DbSet<Park> Park { get; set; }
        public DbSet<KeukenhofWebsite.Models.Admin> Admin { get; set; }
        public DbSet<Pagina> Pagina { get; set; }
        public DbSet<Action> Action { get; set; }
        public DbSet<Zoekterm> Zoekterm { get; set; }
        public DbSet<ZoektermAction> ZoektermAction { get; set; }
    }
}
