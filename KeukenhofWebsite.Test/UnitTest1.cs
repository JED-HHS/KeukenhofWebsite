using KeukenhofWebsite.Controllers;
using KeukenhofWebsite.Models;
using System;
using Xunit;
using Microsoft.EntityFrameworkCore.InMemory;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KeukenhofWebsite.Test
{
    public class UnitTest1
    {
        private readonly KeukenhofWebsiteContext _context;

        private KeukenhofWebsiteContext GetInMemoryDBMetData()
        {
            KeukenhofWebsiteContext context = GetNewInMemoryDatabase();
            context.
            return context;
        }

        private KeukenhofWebsiteContext GetNewInMemoryDatabase()
        {
            var options = new DbContextOptionsBuilder<KeukenhofWebsiteContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            return new KeukenhofWebsiteContext(options);
        }

        [Fact]
        public void Add_writes_to_database()
        {
            KeukenhofWebsiteContext context = GetInMemoryDBMetData();
            var controller = new AdminController(context);
            RedirectToRouteResult result = (RedirectToRouteResult)controller.HetPark();
            
            Assert.AreEqual("Index", result.RouteValues["action"]);


        }
    }
}
