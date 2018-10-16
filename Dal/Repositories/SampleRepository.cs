using Common.Model;
using System.Collections.Generic;

namespace Dal.Repositories
{
    public class SampleRepository
    {
        public static IEnumerable<TestModel> CreateSampleData()
        {
            var output = new List<TestModel>
            {
                new TestModel { Id = 1, Title = "C# Very Easy" },
                new TestModel { Id = 2, Title = "C# Easy" },
                new TestModel { Id = 3, Title = "C# Normal" },
                new TestModel { Id = 4, Title = "C# Hard" },
                new TestModel { Id = 5, Title = "C# Very Hard" }
            };

            return output;
        }
    }
}
