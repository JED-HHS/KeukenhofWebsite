using KeukenhofWebsite.Controllers;
using KeukenhofWebsite.Models;
using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KeukenhofWebsite.Test
{
    public class PaginaTests
    {
        private String databasename;

        private KeukenhofWebsiteContext GetInMemoryDBMetData()
        {
            KeukenhofWebsiteContext context = GetNewInMemoryDatabase(true);
            context.Add(new Pagina { PaginaId = 1, Titel = "Gele Pagina" });
            context.Add(new Pagina { PaginaId = 2, Titel = "Derde Pagina?"});
            context.Add(new Pagina { PaginaId = 3, Titel = "Miauw Pagina?" });
            context.SaveChanges();
            context = GetNewInMemoryDatabase(false);
            return context;
        }

        private KeukenhofWebsiteContext GetNewInMemoryDatabase(bool NewDb)
        {

            if (NewDb)
            {
                this.databasename = Guid.NewGuid().ToString();
            }

            var options = new DbContextOptionsBuilder<KeukenhofWebsiteContext>()
                .UseInMemoryDatabase(this.databasename)
                .Options;

            return new KeukenhofWebsiteContext(options);

        }

        [Fact]
        public async void Pagina_DeleteConfirmed()
        {
            KeukenhofWebsiteContext context = GetInMemoryDBMetData();
            var controller = new PaginasController(context);
            await controller.DeleteConfirmed(2);
            Assert.Empty(context.Pagina.Where(s => s.PaginaId == 2));
            Assert.Equal(2, context.Pagina.Count());
        }

        [Fact]
        public async void Pagina_Edit()
        {
            KeukenhofWebsiteContext context = GetInMemoryDBMetData();
            var controller = new PaginasController(context);
            Pagina Pagina = new Pagina { PaginaId = 1, Titel = "Melk Pagina?"};
            await controller.Edit(1, Pagina);
            Assert.Equal("Melk Pagina?", context.Pagina.FirstOrDefault(s => s.PaginaId == 1).Titel);
        }
        [Fact]
        public async void Pagina_Create()
        {
            KeukenhofWebsiteContext context = GetInMemoryDBMetData();
            var controller = new PaginasController(context);
            Pagina Pagina = new Pagina { PaginaId = 4, Titel = "Test Pagina?" };
            await controller.Create(Pagina);
            Assert.Equal("Test Pagina?", context.Pagina.FirstOrDefault(s => s.PaginaId == 4).Titel);
        }




    }
}