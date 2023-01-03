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
    class AlgorithmControllerTest
    {
        private DependencyResolver _serviceProvider;
        private IAlgorithmService _service;
        private AlgorithmController _controller;


        [SetUp]
        public void Setup()
        {
            var webHost = WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .Build();
            _serviceProvider = new DependencyResolver(webHost);
            _service = _serviceProvider.GetService<IAlgorithmService>();
            _controller = new AlgorithmController(_service);
        }


        [Test]
        public async Task Yogi()
        {
            ReversePostParam param = new ReversePostParam() { StringInput = "Yogi" };
            var result = _controller.Post(param);
            var objectResult = result.Result as ObjectResult;
            var oResult = (AlgorithmResponse)objectResult.Value;

            Assert.NotNull(objectResult);
            Assert.IsTrue(objectResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, objectResult.StatusCode);
            Assert.IsTrue(oResult.Algorithm.Equals("MD5"));
            Assert.IsTrue(oResult.Value.Equals("53522ad67a425c5c0f4ac9fc089fbbb4"));

        }
    }
}
