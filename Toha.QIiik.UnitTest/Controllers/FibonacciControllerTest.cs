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

namespace Toha.QIiik.UnitTest.Controllers
{
    class FibonacciControllerTest
    {
        private DependencyResolver _serviceProvider;
        private IFibonacciService _service;
        private FibonacciController _controller;


        [SetUp]
        public void Setup()
        {
            var webHost = WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .Build();
            _serviceProvider = new DependencyResolver(webHost);
            _service = _serviceProvider.GetService<IFibonacciService>();
            _controller = new FibonacciController(_service);
        }


        [Test]
        public async Task TenFibbo()
        {
            var result = _controller.Post(10);
            var objectResult = result.Result as ObjectResult;
            var oResult = (decimal)objectResult.Value;

            Assert.NotNull(objectResult);
            Assert.IsTrue(objectResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.IsTrue(oResult == 55);
        }


        [Test]
        public async Task TenFibbo3()
        {
            var result = _controller.Post(3);
            var objectResult = result.Result as ObjectResult;
            var oResult = (decimal)objectResult.Value;

            Assert.NotNull(objectResult);
            Assert.IsTrue(objectResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.IsTrue(oResult == 2);
        }

        [Test]
        public async Task BadRequest()
        {
            var result = _controller.Post(-9);
            var objectResult = result.Result as ObjectResult;
            var oResult = objectResult.Value as string;

            Assert.NotNull(objectResult);
            Assert.IsTrue(objectResult is BadRequestObjectResult);
            Assert.AreEqual(StatusCodes.Status400BadRequest, objectResult.StatusCode);
            Assert.IsTrue(oResult.Contains("cannot be negative"));
        }


        [Test]
        public async Task Return1()
        {
            var result = _controller.Post(1);
            var objectResult = result.Result as ObjectResult;
            var oResult = (decimal)objectResult.Value;

            Assert.NotNull(objectResult);
            Assert.IsTrue(objectResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.IsTrue(oResult == 1);
        }



        [Test]
        public async Task Return0()
        {
            var result = _controller.Post(0);
            var objectResult = result.Result as ObjectResult;
            var oResult = (decimal)objectResult.Value;

            Assert.NotNull(objectResult);
            Assert.IsTrue(objectResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.IsTrue(oResult == 0);
        }


        [Test]
        public async Task Return1Val2()
        {
            var result = _controller.Post(2);
            var objectResult = result.Result as ObjectResult;
            var oResult = (decimal)objectResult.Value;

            Assert.NotNull(objectResult);
            Assert.IsTrue(objectResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.IsTrue(oResult == 1);
        }
    }
}
