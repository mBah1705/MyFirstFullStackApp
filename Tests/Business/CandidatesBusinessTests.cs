using AutoMapper;
using Business;
using Common.Models;
using Common.Utility;
using Dal.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests.Business
{
    [TestClass]
    public class CandidatesBusinessTests
    {
        Mock<ICandidatesRepository> mock = new Mock<ICandidatesRepository>();

        MapperConfiguration autoMapperConfiguration = new MapperConfiguration(c =>
        {
            c.AddProfile(new ApplicationProfile());
        });

        [TestMethod]
        public async Task GetCandidates_ShouldReturnAllCandidatesWithTheirScores()
        {
            // Arrange
            mock.Setup(m => m.GetCandidatesAsync())
                .Returns(Task.Run(() => PopulateCandidates()));

            var candidatesBusiness = new CandidatesBusiness(mock.Object, autoMapperConfiguration.CreateMapper());
            var expected = CreateCandidatesWithResultsTests();

            // Act
            var actual = await candidatesBusiness.GetCandidatesAsync();

            // Assert
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
            mock.Setup(m => m.GetCandidatesAsync())
                .Returns(Task.Run(() => PopulateCandidates()));

            var candidatesBusiness = new CandidatesBusiness(mock.Object, autoMapperConfiguration.CreateMapper());
            double expected = CreateCandidatesWithResultsTests().Average(c => c.Score);

            // Act
            double actual = await candidatesBusiness.GetCandidatesAverageAsync();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task GetCandidatesStantdardDeviationAsync_ShouldReturnTheStandardDeviationOfTheCandidatesScores()
        {
            // Arrange
            mock.Setup(m => m.GetCandidatesAsync())
                .Returns(Task.Run(() => PopulateCandidates()));

            var candidatesBusiness = new CandidatesBusiness(mock.Object, autoMapperConfiguration.CreateMapper());
            double avg = CreateCandidatesWithResultsTests().Average(c => c.Score);
            IEnumerable<int> scoresArray = CreateCandidatesWithResultsTests().Select(c => c.Score);
            double sumOfSquareDifferences = scoresArray.Select(s => Math.Pow(s - avg, 2)).Sum();
            double expected = Math.Sqrt(sumOfSquareDifferences / scoresArray.Count());

            // Act
            double actual = await candidatesBusiness.GetCandidatesStantdardDeviationAsync();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        private IEnumerable<CandidateModel>  PopulateCandidates()
        {
            var list = new List<CandidateModel>
            {
                new CandidateModel
                {
                    Id = 1,
                    FirstName = "Test FirstName 1",
                    LastName = "Test LastName 1",
                    TestId = 1,
                    Test = new TestModel
                    {
                        Id = 1,
                        Title = "TestTitle 1"
                    },
                    Result = new []
                    {
                        new ResultModel
                        {
                            Id = 1,
                            CandidateId = 1,
                            AnswerId = 1,
                            Answer = new AnswerModel
                            {
                                Id = 1,
                                IsGood = true
                            }
                        },
                        new ResultModel
                        {
                            Id = 2,
                            CandidateId = 1,
                            AnswerId = 5,
                            Answer = new AnswerModel
                            {
                                Id = 5,
                                IsGood = false
                            }
                        }
                    }
                },
                new CandidateModel
                {
                    Id = 2,
                    FirstName = "Test FirstName 2",
                    LastName = "Test LastName 2",
                    TestId = 1,
                    Test = new TestModel
                    {
                        Id = 1,
                        Title = "TestTitle 1"
                    },
                    Result = new []
                    {
                        new ResultModel
                        {
                            Id = 3,
                            CandidateId = 2,
                            AnswerId = 1,
                            Answer = new AnswerModel
                            {
                                Id = 1,
                                IsGood = true
                            }
                        },
                        new ResultModel
                        {
                            Id = 4,
                            CandidateId = 2,
                            AnswerId = 5,
                            Answer = new AnswerModel
                            {
                                Id = 5,
                                IsGood = false
                            }
                        }
                    }
                },
                new CandidateModel
                {
                    Id = 3,
                    FirstName = "Test FirstName 3",
                    LastName = "Test LastName 3",
                    TestId = 2,
                    Test = new TestModel
                    {
                        Id = 2,
                        Title = "TestTitle 2"
                    },
                    Result = new []
                    {
                        new ResultModel
                        {
                            Id = 5,
                            CandidateId = 3,
                            AnswerId = 14,
                            Answer = new AnswerModel
                            {
                                Id = 14,
                                IsGood = true
                            }
                        },
                        new ResultModel
                        {
                            Id = 6,
                            CandidateId = 3,
                            AnswerId = 19,
                            Answer = new AnswerModel
                            {
                                Id = 19,
                                IsGood = true
                            }
                        }
                    }
                }
            };
            return list;
        }

        private IEnumerable<CandidateWithResultModel> CreateCandidatesWithResultsTests()
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
    }
}
 