using System.Collections.Generic;
using Common.Model;

namespace Dal.Repositories
{
    public interface ISampleRepository
    {
        IEnumerable<TestModel> CreateSampleData();
    }
}