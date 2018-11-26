using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public interface ISampleBusiness
    {
        Task<IEnumerable<string>> GetTestsAsync();
        Task<string> GetTestByIdAsync(int id);
    }
}