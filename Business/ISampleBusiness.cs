using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public interface ISampleBusiness
    {
        Task<IEnumerable<string>> ListAllTestsAsync();
        Task<string> ListOneTestAsync(int id);
    }
}