﻿using Api.Controllers;
using Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests.Api
{
    [TestClass]
    public class SampleControllerTests
    {
        Mock<ISampleBusiness> mock = new Mock<ISampleBusiness>();

        [TestMethod]
        public async Task GetAsync_ReturnsAListOfAllTests()
        {
            // Arrange
            mock.Setup(m => m.GetTestsAsync())
                .Returns(Task.Run(() => GetSampleTests()));

            var sampleController = new SampleController(mock.Object);

            var expected = GetSampleTests();

            // Act
            var result = await sampleController.GetAsync();

            // Assert
            var okObjectResult = result as OkObjectResult;
            Assert.IsNotNull(okObjectResult);

            var actual = okObjectResult.Value as IEnumerable<string>;
            Assert.IsNotNull(actual);

            Assert.AreEqual(expected.Count(), actual.Count());

            for (int i = 0; i < expected.Count(); i++)
            {
                Assert.AreEqual(expected.ElementAt(i), actual.ElementAt(i));
            }
        }

        [TestMethod]
        public async Task GetAsync_WhenIdExists_ReturnsTheTestWithTheGivenId()
        {
            // Arrange
            int testId = 1;
            mock.Setup(m => m.GetTestByIdAsync(testId))
                .Returns(Task.Run(() => GetSampleTests().ElementAt(testId)));

            var sampleController = new SampleController(mock.Object);

            var expected = GetSampleTests().ElementAt(testId);

            // Act
            var result = await sampleController.GetAsync(testId);

            // Assert
            var okObjectResult = result as OkObjectResult;
            Assert.IsNotNull(okObjectResult);

            var actual = okObjectResult.Value as string;
            Assert.IsNotNull(actual);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task GetAsync_WhenIdDoesntExist_ReturnsNotFound()
        {
            // Arrange
            mock.Setup(m => m.GetTestByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(null as string);

            var sampleController = new SampleController(mock.Object);

            var expected = 404;

            // Act
            var actual = await sampleController.GetAsync(1) as NotFoundResult;

            // Assert
            Assert.AreEqual(expected, actual.StatusCode);
        }

        private IEnumerable<string> GetSampleTests()
        {
            var list = new List<string>
            {
                "sample 1",
                "sample 2",
                "sample 3"
            };
            return list;
        }
    }
}
