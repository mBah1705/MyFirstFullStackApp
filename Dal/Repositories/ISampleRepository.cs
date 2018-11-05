using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Model;

namespace Dal.Repositories
{
    public interface ISampleRepository
    {
        Task<IEnumerable<TestModel>> GetTestsAsync();
        Task<TestModel> GetTestByIdAsync(int id);
    }
}