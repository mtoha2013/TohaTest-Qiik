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
    class ReverseWordControllerTest
    {
        IReverseWordService _service;
        private DependencyResolver _serviceDI;
        private ReverseWordController _controller;


        [SetUp]
        public void Setup()
        {
            var webHost = WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .Build();
            _serviceDI = new DependencyResolver(webHost);
            _service = _serviceDI.GetService<IReverseWordService>();
            _controller = new ReverseWordController(_service);
        }


        [Test]
        public async Task TenYogi()
        {
            ReversePostParam param = new ReversePostParam() { StringInput = "Yogi" };

            var result = _controller.Post(param);
            var objectResult = result.Result as ObjectResult;
            var oResult = (string)objectResult.Value;

            Assert.NotNull(objectResult);
            Assert.IsTrue(objectResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.IsTrue(oResult.Equals("igoY"));
        }



        [Test]
        public async Task TenToha()
        {
            ReversePostParam param = new ReversePostParam() { StringInput = "Toha" };
            var result = _controller.Post(param);
            var objectResult = result.Result as ObjectResult;
            var oResult = (string)objectResult.Value;

            Assert.NotNull(objectResult);
            Assert.IsTrue(objectResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.IsTrue(oResult.Equals("ahoT"));
        }




        [Test]
        public async Task TenMToha()
        {
            ReversePostParam param = new ReversePostParam() { StringInput = "MToha" };

            var result = _controller.Post(param);
            var objectResult = result.Result as ObjectResult;
            var oResult = (string)objectResult.Value;

            Assert.NotNull(objectResult);
            Assert.IsTrue(objectResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.IsTrue(oResult.Equals("ahoTM"));
        }
    }
}
