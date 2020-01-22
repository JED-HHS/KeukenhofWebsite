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
    public class ContentTests
    {

        private String databasename;

        private KeukenhofWebsiteContext GetInMemoryDBMetData()
        {
            KeukenhofWebsiteContext context = GetNewInMemoryDatabase(true);
            context.Add(new Content { ContentId = 1, Titel = "Text-Links", Tekst = "hallo ik ben text en ik sta links" });
            context.Add(new Content { ContentId = 2, Titel = "Titel", Tekst = "Dit is een titel" });
            context.Add(new Content { ContentId = 3, Titel = "Lezen", Tekst = "Lees Meer" });
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
        public async void Content_DeleteConfirmed()
        {
            KeukenhofWebsiteContext context = GetInMemoryDBMetData();
            var controller = new ContentController(context);
            await controller.DeleteConfirmed(2);
            Assert.Empty(context.Content.Where(s => s.ContentId == 2));
            Assert.Equal(2, context.Content.Count());
        }

        [Fact]
        public async void Content_Edit()
        {
            KeukenhofWebsiteContext context = GetInMemoryDBMetData();
            var controller = new ContentController(context);
            Content content = new Content { ContentId = 1, Titel = "Miauw?", Tekst = "Van Jiauw" };
            await controller.Edit(1, content);
            Assert.Equal("Miauw?", context.Content.FirstOrDefault(s => s.ContentId == 1).Titel);
        }
        [Fact]
        public async void Content_Create()
        {
            KeukenhofWebsiteContext context = GetInMemoryDBMetData();
            var controller = new ContentController(context);
            Content content = new Content { ContentId = 4, Titel = "TekstTitel?", Tekst = "TestTekst" };
            await controller.Create(content);
            Assert.Equal("TekstTitel?", context.Content.FirstOrDefault(s => s.ContentId == 4).Titel);
        }
    }
}
