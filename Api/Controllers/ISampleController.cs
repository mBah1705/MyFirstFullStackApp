using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public interface ISampleController
    {
        void Delete(int id);
        Task<IActionResult> GetAsync();
        Task<IActionResult> GetAsync(int id);
        void Post([FromBody] string value);
        void Put(int id, [FromBody] string value);
    }
}