using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Toha.QIiik.Web;
using Toha.QIiik.Web.Controllers;
using Toha.QIiik.Web.Interfaces;
using Toha.QIiik.Web.Models;

namespace Toha.QIiik.UnitTest.Controllers
{
    [TestFixture]
    public class TriangleControllerTest
    {

        private DependencyResolver _serviceProvider;
        private ITriangleService _service;
        private TriangleController _controller;


        [SetUp]
        public void Setup()
        {
            var webHost = WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .Build();
            _serviceProvider = new DependencyResolver(webHost);
            _service = _serviceProvider.GetService<ITriangleService>();
            _controller = new TriangleController(_service);
        }



        [Test]
        public async Task Scalene()
        {
            TrianglePostParam param = new TrianglePostParam();
            param.LengthSide1 = 1;
            param.LengthSide2 = 2;
            param.LengthSide3 = 3;

            var result = _controller.Post(param);
            var objectResult = result.Result as ObjectResult;
            var oResult = objectResult.Value as string;

            Assert.NotNull(objectResult);
            Assert.IsTrue(objectResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.IsTrue(oResult.Contains("Scalene"));
        }


        [Test]
        public async Task Isosceles()
        {
            TrianglePostParam param = new TrianglePostParam();
            param.LengthSide1 = 2;
            param.LengthSide2 = 2;
            param.LengthSide3 = 3;

            var result = _controller.Post(param);
            var objectResult = result.Result as ObjectResult;
            var oResult = objectResult.Value as string;

            Assert.NotNull(objectResult);
            Assert.IsTrue(objectResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.IsTrue(oResult.Contains("Isosceles"));
        }

        [Test]
        public async Task Isosceles2()
        {
            TrianglePostParam param = new TrianglePostParam();
            param.LengthSide1 = 2;
            param.LengthSide2 = 3;
            param.LengthSide3 = 3;

            var result = _controller.Post(param);
            var objectResult = result.Result as ObjectResult;
            var oResult = objectResult.Value as string;

            Assert.NotNull(objectResult);
            Assert.IsTrue(objectResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.IsTrue(oResult.Contains("Isosceles"));
        }

        [Test]
        public async Task Equilateral()
        {
            TrianglePostParam param = new TrianglePostParam();
            param.LengthSide1 = 3;
            param.LengthSide2 = 3;
            param.LengthSide3 = 3;

            var result = _controller.Post(param);
            var objectResult = result.Result as ObjectResult;
            var oResult = objectResult.Value as string;

            Assert.NotNull(objectResult);
            Assert.IsTrue(objectResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.IsTrue(oResult.Contains("Equilateral"));
        }

    }
}
