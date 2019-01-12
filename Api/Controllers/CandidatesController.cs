using Business;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidatesBusiness _candidatesBusiness;

        public CandidatesController(ICandidatesBusiness candidatesBusiness)
        {
            _candidatesBusiness = candidatesBusiness;
        }

        // GET: api/Candidates
        [HttpGet]
        public async Task<IActionResult> GetCandidatesAsync()
        {
            return Ok(await _candidatesBusiness.GetCandidatesAsync());
        }

        //GET: api/Candidates/Average
        [HttpGet("Average")]
        public async Task<IActionResult> GetCandidatesAverageAsync()
        {
            return Ok(await _candidatesBusiness.GetCandidatesAverageAsync());
        }

        //GET: api/Candidates/StandardDeviation
        [HttpGet("StandardDeviation")]
        public async Task<IActionResult> GetCandidatesStantdardDeviationAsync()
        {
            return Ok(await _candidatesBusiness.GetCandidatesStantdardDeviationAsync());
        }

        // POST: api/Candidates
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Candidates/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
