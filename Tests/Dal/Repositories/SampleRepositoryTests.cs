using AutoMapper;
using Common.Models;
using Common.Utility;
using Dal.DBContext;
using Dal.Entities;
using Dal.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests.Dal.Repositories
{
    [TestClass]
    public class SampleRepositoryTests
    {
        [TestMethod]
        public async Task GetTestsAsync_ShouldReturnTheListOfTests()
        {
            // Arrange
            var tests = CreateProperTestsInMemory();

            IEnumerable<TestModel> expected = GetProperSampleData();

            // Act
            var actual = await tests.GetTestsAsync() as IEnumerable<TestModel>;

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), actual.Count());

            for (int i = 0; i < expected.Count(); i++)
            {
                Assert.AreEqual(expected.ElementAt(i).Id, actual.ElementAt(i).Id);
                Assert.AreEqual(expected.ElementAt(i).Title, actual.ElementAt(i).Title);
            }
        }

        [TestMethod]
        public async Task GetTestByIdAsync_WithSingleExistingIds_ShouldReturnTheProperTestSample()
        {
            // Arrange
            int testId = 1;
            var tests = CreateProperTestsInMemory();

            TestModel expected = GetProperSampleData().ElementAt(testId -1);

            // Act
            var actual = await tests.GetTestByIdAsync(testId) as TestModel;

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Title, actual.Title);
        }

        [TestMethod]
        public async Task GetTestByIdAsync_WithNonExistingId_ShouldNotReturnAnyValue()
        {
            // Arrange
            int testId = 3;
            var tests = CreateProperTestsInMemory();

            // Act
            var actual = await tests.GetTestByIdAsync(testId);

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetTestByIdAsync_WithRepeatedId_ShouldThrowAnException()
        {
            // Arrange
            int testId = 1;

            // Assert
            Assert.ThrowsExceptionAsync<InvalidOperationException>(() => CreateTestsWithRepeatedIdsInMemory()
            .GetTestByIdAsync(testId));
        }

        private ISampleRepository CreateProperTestsInMemory()
        {
            var dbOptions = new DbContextOptionsBuilder<MyFirstFullStackApp_DEVContext>()
                                .UseInMemoryDatabase(databaseName: "MyFFSADb")
                                .Options;
            var context = new MyFirstFullStackApp_DEVContext(dbOptions);
            SeedProperTestsToDb(context);

            var autoMapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile(new ApplicationProfile());
            });
            return new SampleRepository(context, autoMapperConfiguration.CreateMapper());
        }

        private ISampleRepository CreateTestsWithRepeatedIdsInMemory()
        {
            var dbOptions = new DbContextOptionsBuilder<MyFirstFullStackApp_DEVContext>()
                                .UseInMemoryDatabase(databaseName: "MyFFSADb")
                                .Options;
            var context = new MyFirstFullStackApp_DEVContext(dbOptions);
            SeedTestsWithRepeatedIdsToDb(context);

            var autoMapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile(new ApplicationProfile());
            });
            return new SampleRepository(context, autoMapperConfiguration.CreateMapper());
        }

        private void SeedProperTestsToDb(MyFirstFullStackApp_DEVContext context)
        {
            
            var tests = new[]
            {
                new Test
                {
                    Id = 1,
                    Title = "Test testModel1"
                },
                new Test
                {
                    Id = 2,
                    Title = "Test testModel2"
                }
            };

            if(context.Test.Count() != 0)
            {
                foreach(Test test in context.Test)
                {
                    context.Test.Remove(test);
                }
            }

            context.Test.AddRange(tests);
            context.SaveChanges();
        }

        private void SeedTestsWithRepeatedIdsToDb(MyFirstFullStackApp_DEVContext context)
        {
            var tests = new[]
            {
                new Test
                {
                    Id = 1,
                    Title = "Test testModel1"
                },
                new Test
                {
                    Id = 1,
                    Title = "Test testModel1"
                }
            };

            if (context.Test.Count() != 0)
            {
                foreach (Test test in context.Test)
                {
                    context.Test.Remove(test);
                }
            }

            context.Test.AddRange(tests);
            context.SaveChanges();
        }

        private IEnumerable<TestModel> GetProperSampleData()
        {
            var list = new List<TestModel>
            {
                new TestModel
                {
                    Id = 1,
                    Title = "Test testModel1"
                },
                new TestModel
                {
                    Id = 2,
                    Title = "Test testModel2"
                }
            };
            return list;
        }
    }
}
