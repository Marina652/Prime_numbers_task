using Moq;
using MyTask.Controllers;
using Microsoft.AspNetCore.Mvc;
using MyTask.Models;
using MyTask.Repository;
using FluentAssertions;

namespace TestProject
{
    [TestFixture]
    internal class ControllerTests
    {
        private PrimeNumberController _controller;

        [SetUp]
        public void Setup()
        {
            var mock = new Mock<INumberRepository>();

            mock.Setup(x => x.GetCalculatedNumbers()).Returns(TestData());

            _controller = new PrimeNumberController(mock.Object);
        }

        [Test]
        public async Task ControllerTest_WhenNumberIsNotPrimeAndExistInDb_Return200()
        {
            var res = await _controller.IsThisAPrimeNumber(5);

            res.Should().BeOfType<OkResult>();
        }

        [Test]
        public async Task ControllerTest_WhenNumberIsPrimeAndExistInDb_Return200()
        {
            var res = await _controller.IsThisAPrimeNumber(4);

            res.Should().BeOfType<BadRequestObjectResult>();
        }


        [Test]
        public async Task ControllerTest_WhenNumberIsPrimeAndNotExistInDb_Return200()
        {
            var res = await _controller.IsThisAPrimeNumber(7);

            res.Should().BeOfType<OkResult>();
        }


        [Test]
        public async Task ControllerTest_WhenNumberIsNotPrimeAndNotExistInDb_Return200()
        {
            var res = await _controller.IsThisAPrimeNumber(6);

            res.Should().BeOfType<BadRequestObjectResult>();
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
