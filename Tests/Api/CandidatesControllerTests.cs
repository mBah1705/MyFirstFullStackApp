using Api.Controllers;
using Business;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests.Api
{
    [TestClass]
    public class CandidatesControllerTests
    {
        Mock<ICandidatesBusiness> mock = new Mock<ICandidatesBusiness>();

        [TestMethod]
        public async Task GetAsync_ReturnsAListOfCandidatesWithTheirScores()
        {
            // Arrange
            mock.Setup(m => m.GetCandidatesAsync())
                .Returns(Task.Run(() => PopulateCandidatesWithResults()));

            var candidatesController = new CandidatesController(mock.Object);

            var expected = PopulateCandidatesWithResults();

            // Act
            var result = await candidatesController.GetCandidatesAsync();

            // Assert
            var okObjectResult = result as OkObjectResult;
            Assert.IsNotNull(okObjectResult);

            var actual = okObjectResult.Value as IEnumerable<CandidateWithResultModel>;
            Assert.IsNotNull(actual);

            Assert.AreEqual(expected.Count(), actual.Count());

            for (int i = 0; i < expected.Count(); i++)
            {
                Assert.AreEqual(expected.ElementAt(i).TestTitle, actual.ElementAt(i).TestTitle);
                Assert.AreEqual(expected.ElementAt(i).Score, actual.ElementAt(i).Score);
            }
        }

        [TestMethod]
        public async Task GetCandidatesAverageAsync_ShouldReturnTheAverageOfTheCandidatesScores()
        {
            // Arrange
            mock.Setup(m => m.GetCandidatesAverageAsync())
                .Returns(Task.Run(() => PopulateCandidatesWithResults().Average(c => c.Score)));

            var candidatesController = new CandidatesController(mock.Object);

            double expected = PopulateCandidatesWithResults().Average(c => c.Score);

            // Act
            var result = await candidatesController.GetCandidatesAverageAsync();

            // Assert
            var okObjectResult = result as OkObjectResult;
            Assert.IsNotNull(okObjectResult);

            var actual = okObjectResult.Value;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task GetCandidatesStantdardDeviationAsync_ShouldReturnTheStantdardDeviationOfTheCandidatesScores()
        {
            // Arrange
            mock.Setup(m => m.GetCandidatesStantdardDeviationAsync())
                .Returns(Task.Run(() => CalculateStdDeviation(PopulateCandidatesWithResults())));

            var candidatesController = new CandidatesController(mock.Object);

            double expected = CalculateStdDeviation(PopulateCandidatesWithResults());

            // Act
            var result = await candidatesController.GetCandidatesStantdardDeviationAsync();

            // Assert
            var okObjectResult = result as OkObjectResult;
            Assert.IsNotNull(okObjectResult);

            var actual = okObjectResult.Value;

            Assert.AreEqual(expected, actual);
        }

        private IEnumerable<CandidateWithResultModel> PopulateCandidatesWithResults()
        {
            var list = new List<CandidateWithResultModel>
            {
                new CandidateWithResultModel
                {
                    Id = 1,
                    FirstName = "Test FirstName 1",
                    LastName = "Test LastName 1",
                    TestId = 1,
                    TestTitle = "TestTitle 1",
                    Score = 10
                },
                new CandidateWithResultModel
                {
                    Id = 2,
                    FirstName = "Test FirstName 2",
                    LastName = "Test LastName 2",
                    TestId = 1,
                    TestTitle = "TestTitle 1",
                    Score = 10
                },
                new CandidateWithResultModel
                {
                    Id = 3,
                    FirstName = "Test FirstName 3",
                    LastName = "Test LastName 3",
                    TestId = 2,
                    TestTitle = "TestTitle 2",
                    Score = 20
                }
            };
            return list;
        }

        private double CalculateStdDeviation(IEnumerable<CandidateWithResultModel> candidates)
        {
            double avg = candidates.Average(c => c.Score);
            IEnumerable<int> scoresArray = candidates.Select(c => c.Score);
            double sumOfSquareDifferences = scoresArray.Select(s => Math.Pow(s - avg, 2)).Sum();
            double sd = Math.Sqrt(sumOfSquareDifferences / scoresArray.Count());

            return sd;
        }
    }
}
