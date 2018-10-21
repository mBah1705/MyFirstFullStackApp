using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Get()
        {
            return Ok(_sampleBusiness.ListAllData());
        }

        // GET: api/Sample/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            return Ok(_sampleBusiness.ListOneData(id));
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
