using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using MyTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Moq;
using NUnit.Framework.Internal.Execution;
using MyTask.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TestProject
{
    [TestFixture]
    internal class ControllerTests
    {
        private PrimeController _controller;

        [SetUp]
        public void Setup()
        {
            var mock = new Mock<INumberRepository>();

            mock.Setup(x => x.GetNumbers()).Returns(TestData());

            _controller = new PrimeController(mock.Object);
        }

        [Test]
        public async Task ControllerTest_WhenNumberIsNotPrimeAndExistInDb_Return200()
        {
            var res = await _controller.IsThisAPrimeNumber(5);

            var actual = (HttpStatusCode) res
                .GetType()
                .GetProperty("StatusCode")
                .GetValue(res, null);

            Assert.That(actual, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task ControllerTest_WhenNumberIsPrimeAndExistInDb_Return200()
        {
            var res = await _controller.IsThisAPrimeNumber(4);

            var actual = (HttpStatusCode)res
                .GetType()
                .GetProperty("StatusCode")
                .GetValue(res, null);

            Assert.That(actual, Is.EqualTo(HttpStatusCode.BadRequest));
        }


        [Test]
        public async Task ControllerTest_WhenNumberIsPrimeAndNotExistInDb_Return200()
        {
            var res = await _controller.IsThisAPrimeNumber(7);

            var actual = (HttpStatusCode)res
                .GetType()
                .GetProperty("StatusCode")
                .GetValue(res, null);

            Assert.That(actual, Is.EqualTo(HttpStatusCode.OK));
        }


        [Test]
        public async Task ControllerTest_WhenNumberIsNotPrimeAndNotExistInDb_Return200()
        {
            var res = await _controller.IsThisAPrimeNumber(6);

            var actual = (HttpStatusCode)res
                .GetType()
                .GetProperty("StatusCode")
                .GetValue(res, null);

            Assert.That(actual, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        private static Task<List<NumberModel>> TestData()
        {
            var list = new List<NumberModel>();

            list.Add(new NumberModel 
            { 
                Number = 4,
                IsPrime = false
            });

            list.Add(new NumberModel
            {
                Number = 5,
                IsPrime = true
            });

            return Task.FromResult(list);

        }
    }
}
