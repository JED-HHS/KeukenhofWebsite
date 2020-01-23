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

        private readonly KeukenhofWebsiteContext _context;


        [Theory]
        [InlineData("/")]
        [InlineData("/HetPark")]
        [InlineData("/Content")]
        [InlineData("/FAQ")]
        [InlineData("/_Contact")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            HomeController c = new HomeController();
            //var client = c.C
        }

        [Fact]
        public void HetParkTesten()
        {
            HomeController c = new HomeController();
            var result = c.HetPark() as ViewResult;
            var obj = new ViewResult();
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Home", redirectToActionResult.ControllerName);
            Assert.Equal("HetPark", redirectToActionResult.ActionName);
            //var ViewResult = Assert.IsType<ViewResult>(result);
            //var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            //Assert.Equal(obj.GetType(), result.GetType());
           

         
        }

        [Fact]
        public void FAQTesten()
        {
            HomeController c = new HomeController();
            var result = c.FAQ() as ViewResult;
            var myModel = (IEnumerable<KeukenhofWebsite.Models.QenA>)result.Model;
            //var viewResult = Assert.IsType<ViewResult>(result);
            //var model = viewResult.ViewData.Model;
            Assert.NotNull(result);
            Assert.NotNull(result.Model); // add additional checks on the Model
            Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "FAQ");
        }

        /*var obj = new ViewResult();
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Home", redirectToActionResult.ControllerName);
        Assert.Equal("FAQ", redirectToActionResult.ActionName);*/


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
            var result = c.Content() as ViewResult;
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
            var result = c._Contact() as ViewResult;
           //var myModel = (_context.QenA.ToList())result.Model;
            //var viewResult = Assert.IsType<ViewResult>(result);
            //var model = viewResult.ViewData.Model;
            Assert.Null(result);
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
