using AutoMapper;
using Common.Models;
using Common.Utility;
using Dal.DBContext;
using Dal.Entities;
using Dal.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests.Dal.Repositories
{
    [TestClass]
    public class CandidatesRepositoryTests
    {
        private readonly Test myTest = new Test
        {
            Id = 1,
            Title = "TestTitle 1"
        };

        [TestMethod]
        public async Task GetCandidatesAsync_ShouldReturnTheListOfCandidatesWithTheirRespectiveTestIds()
        {
            // Arrange
            var candidates = CreateProperCandidatesInMemory();

            IEnumerable<CandidateModel> expected = GetProperCandidatesTestsData();

            // Act
            var actual = await candidates.GetCandidatesAsync() as IEnumerable<CandidateModel>;

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), actual.Count());

            for (int i = 0; i < expected.Count(); i++)
            {
                Assert.AreEqual(expected.ElementAt(i).Id, actual.ElementAt(i).Id);
                Assert.AreEqual(expected.ElementAt(i).FirstName, actual.ElementAt(i).FirstName);
                Assert.AreEqual(expected.ElementAt(i).LastName, actual.ElementAt(i).LastName);
                Assert.AreEqual(expected.ElementAt(i).TestId, actual.ElementAt(i).TestId);
            }
        }

        [TestMethod]
        public async Task GetCandidatesAsync_ShouldReturnTheListOfCandidatesWithTheCorrespondingTestTitles()
        {
            // Arrange
            var candidates = CreateProperCandidatesInMemory();

            IEnumerable<CandidateModel> expected = GetProperCandidatesTestsData();

            // Act
            var actual = await candidates.GetCandidatesAsync() as IEnumerable<CandidateModel>;
            actual = actual.OrderBy(c => c.Id);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), actual.Count());

            for (int i = 0; i < expected.Count(); i++)
            {
                Assert.AreEqual(expected.ElementAt(i).Id, actual.ElementAt(i).Id);
                Assert.AreEqual(expected.ElementAt(i).FirstName, actual.ElementAt(i).FirstName);
                Assert.AreEqual(expected.ElementAt(i).LastName, actual.ElementAt(i).LastName);
                Assert.AreEqual(expected.ElementAt(i).Test.Title, actual.ElementAt(i).Test.Title);
            }
        }

        [TestMethod]
        public async Task GetCandidatesAsync_ShouldReturnTheListOfCandidatesWithTheCorrespondingResultAnswers()
        {
            // Arrange
            var candidates = CreateProperCandidatesInMemory();

            IEnumerable<CandidateModel> expected = GetProperCandidatesTestsData();

            // Act
            var actual = await candidates.GetCandidatesAsync() as IEnumerable<CandidateModel>;
            actual = actual.OrderBy(c => c.Id);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), actual.Count());

            for (int i = 0; i < expected.Count(); i++)
            {
                Assert.AreEqual(expected.ElementAt(i).Id, actual.ElementAt(i).Id);
                Assert.AreEqual(expected.ElementAt(i).FirstName, actual.ElementAt(i).FirstName);
                Assert.AreEqual(expected.ElementAt(i).LastName, actual.ElementAt(i).LastName);
                for (int j = 0; j < expected.ElementAt(i).Result.Count; j++)
                {
                    Assert.AreEqual(expected.ElementAt(i).Result.ElementAt(j).Answer.Id, actual.ElementAt(i).Result.ElementAt(j).Answer.Id);
                }
            }
        }

        private ICandidatesRepository CreateProperCandidatesInMemory()
        {
            var dbOptions = new DbContextOptionsBuilder<MyFirstFullStackApp_DEVContext>()
                                .UseInMemoryDatabase(databaseName: "MyFFSADb")
                                .Options;
            var context = new MyFirstFullStackApp_DEVContext(dbOptions);

            SeedProperCandidatesToDb(context);

            var autoMapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile(new ApplicationProfile());
            });
            return new CandidatesRepository(context, autoMapperConfiguration.CreateMapper());
        }

        private void SeedProperCandidatesToDb(MyFirstFullStackApp_DEVContext context)
        {
            context.Candidate.RemoveRange(context.Candidate);
            context.Test.RemoveRange(context.Test);
            context.Result.RemoveRange(context.Result);
            context.Answer.RemoveRange(context.Answer);
            context.SaveChanges();

            var candidates = PopulateCandidates();

            context.Candidate.AddRange(candidates);
            context.SaveChanges();
        }

        private IEnumerable<CandidateModel> GetProperCandidatesTestsData()
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

        private IEnumerable<Candidate> PopulateCandidates()
        {
            var list = new List<Candidate>
            {
                new Candidate
                {
                    Id = 1,
                    FirstName = "Test FirstName 1",
                    LastName = "Test LastName 1",
                    TestId = 1,
                    Test = myTest,
                    Result = {
                        new Result
                        {
                            Id = 1,
                            CandidateId = 1,
                            AnswerId = 1,
                            Answer = new Answer
                            {
                                Id = 1,
                                IsGood = true
                            }
                        },
                        new Result
                        {
                            Id = 2,
                            CandidateId = 1,
                            AnswerId = 5,
                            Answer = new Answer
                            {
                                Id = 5,
                                IsGood = false
                            }
                        },
                    }
                },
                new Candidate
                {
                    Id = 2,
                    FirstName = "Test FirstName 2",
                    LastName = "Test LastName 2",
                    TestId = 1,
                    Test = myTest,
                    Result = {
                        new Result
                        {
                            Id = 3,
                            CandidateId = 2,
                            AnswerId = 1,
                            Answer = new Answer
                            {
                                Id = 1,
                                IsGood = true
                            }
                        },
                        new Result
                        {
                            Id = 4,
                            CandidateId = 2,
                            AnswerId = 5,
                            Answer = new Answer
                            {
                                Id = 5,
                                IsGood = false
                            }
                        },
                    }
                },
                new Candidate
                {
                    Id = 3,
                    FirstName = "Test FirstName 3",
                    LastName = "Test LastName 3",
                    TestId = 2,
                    Test = new Test
                    {
                        Id = 2,
                        Title = "TestTitle 2"
                    },
                    Result = {
                        new Result
                        {
                            Id = 5,
                            CandidateId = 3,
                            AnswerId = 14,
                            Answer = new Answer
                            {
                                Id = 14,
                                IsGood = true
                            }
                        },
                        new Result
                        {
                            Id = 6,
                            CandidateId = 3,
                            AnswerId = 19,
                            Answer = new Answer
                            {
                                Id = 19,
                                IsGood = true
                            }
                        },
                    }
                }
            };
            return list;
        }
    }
}
