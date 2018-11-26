using Business;
using Common.Model;
using Dal.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests.Business
{
    [TestClass]
    public class SampleBusinessTests
    {
        Mock<ISampleRepository> mock = new Mock<ISampleRepository>();

        [TestMethod]
        public async Task GetTestsAsync_ReturnsTheListOfAllTests()
        {
            // Arrange
            mock.Setup(m => m.GetTestsAsync())
                .Returns(Task.Run(() => GetSampleTests()));

            var sampleBusiness = new SampleBusiness(mock.Object);

            var expected = GetSampleTests().Select(t => t.Title);

            // Act
            var actual = await sampleBusiness.GetTestsAsync();

            // Assert
            Assert.IsNotNull(actual);

            Assert.AreEqual(expected.Count(), actual.Count());

            for (int i = 0; i < expected.Count(); i++)
            {
                Assert.AreEqual(expected.ElementAt(i), actual.ElementAt(i));
            }
        }

        [TestMethod]
        public async Task GetTestByIdAsync_WhenGivenAValidId_ReturnsTheEquivalentTest()
        {
            // Arrange
            int testId = 1;
            mock.Setup(m => m.GetTestByIdAsync(testId))
                .Returns(Task.Run(() => GetSampleTests().SingleOrDefault(t => t.Id == testId)));

            var sampleBusiness = new SampleBusiness(mock.Object);

            string expected = GetSampleTests().SingleOrDefault(t => t.Id == testId).Title;

            // Act
            string actual = await sampleBusiness.GetTestByIdAsync(testId);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
        }

        private IEnumerable<TestModel> GetSampleTests()
        {
            var list = new List<TestModel>
            {
               new TestModel { Id = 1, Title = "test 1" },
               new TestModel { Id = 2, Title = "test 2" },
               new TestModel { Id = 3, Title = "test 3" },
            };
            return list;
        }
    }
}
