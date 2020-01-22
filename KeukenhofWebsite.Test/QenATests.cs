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
    public class QenAtests
    {
        private String databasename;

        private KeukenhofWebsiteContext GetInMemoryDBMetData()
        {
            KeukenhofWebsiteContext context = GetNewInMemoryDatabase(true);
            context.Add(new QenA { AnswerId= 1, Question= "Welke kleur is blauw?", Answer= "Blauw" });
            context.Add(new QenA { AnswerId = 2, Question = "Welke kaas is blauw?", Answer = "Red" });
            context.Add(new QenA { AnswerId = 3, Question = "Welke kleur is Miauw?", Answer = "Miauw" });
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
        public async void QenA_DeleteConfirmed()
        {
            KeukenhofWebsiteContext context = GetInMemoryDBMetData();
            var controller = new QenAController(context);
            await controller.DeleteConfirmed(2);
            Assert.Empty(context.QenA.Where(s => s.AnswerId == 2));
            Assert.Equal(2, context.QenA.Count());
        }

        [Fact]
        public async void QenA_Edit()
        {
            KeukenhofWebsiteContext context = GetInMemoryDBMetData();
            var controller = new QenAController(context);
            QenA qenA = new QenA { AnswerId = 1, Question = "Melk?", Answer = "Ja" };
            await controller.Edit(1,qenA);
            Assert.Equal("Melk?", context.QenA.FirstOrDefault(s => s.AnswerId == 1).Question);
        }
        [Fact]
        public async void QenA_Create()
        {
            KeukenhofWebsiteContext context = GetInMemoryDBMetData();
            var controller = new QenAController(context);
            QenA qenA = new QenA { AnswerId = 4, Question = "Geitenmelk?", Answer = "Nee" };
            await controller.Create(qenA);
            Assert.Equal("Geitenmelk?", context.QenA.FirstOrDefault(s => s.AnswerId == 4).Question);
        }




    }
}
