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
    public class HomeTests
    {
        [Fact]
        public void HetParkTesten()
        {
            HomeController c = new HomeController();
            ViewResult result = c.HetPark() as ViewResult;
            Assert.NotNull(result);
        }

        [Fact]
        public void FAQTesten()
        {
            HomeController c = new HomeController();
            ViewResult result = c.FAQ() as ViewResult;
            Assert.NotNull(result);
        }

        [Fact]
        public void EvenementenTesten()
        {
            HomeController c = new HomeController();
            ViewResult result = c.Evenementen() as ViewResult;
            Assert.NotNull(result);
        }
        [Fact]
        public void ContentTesten()
        {
            HomeController c = new HomeController();
            ViewResult result = c.Content() as ViewResult;
            Assert.NotNull(result);
        }

        [Fact]
        public void BereikbaarheidTesten()
        {
            HomeController c = new HomeController();
            ViewResult result = c.Bereikbaarheid() as ViewResult;
            Assert.NotNull(result);
        }

        [Fact]
        public void ContactTesten()
        {
            HomeController c = new HomeController();
            ViewResult result = c._Contact() as ViewResult;
            Assert.NotNull(result);
        }

        /*[Fact]
        public void PraktischeInformatieTesten()
        {
            HomeController c = new HomeController();
            ViewResult result = c.PraktischeInformatie() as ViewResult;
            Assert.NotNull(result);
        }*/

    }
}
