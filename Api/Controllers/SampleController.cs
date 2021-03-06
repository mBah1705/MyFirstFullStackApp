﻿using Business;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly ISampleBusiness _sampleBusiness;

        public SampleController(ISampleBusiness sampleBusiness)
        {
            _sampleBusiness = sampleBusiness;
        }

        // GET: api/Sample
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _sampleBusiness.GetTestsAsync());
        }

        // GET: api/Sample/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _sampleBusiness.GetTestByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: api/Sample
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Sample/5
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
