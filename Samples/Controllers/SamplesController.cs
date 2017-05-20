using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Samples.Core.Models;
using Samples.Core.Repositories;

namespace Samples.Controllers
{
    [Route("api/[controller]")]
    public class SamplesController : Controller
    {
        private readonly ISamplesAppRepository _repository;

        public SamplesController(ISamplesAppRepository repository)
        {
            _repository = repository;
        }

        // GET api/Samples
        [HttpGet]
        public IActionResult Get([FromQuery] int? status, [FromQuery] string name)
        {
            var samples = _repository.GetSamples(status, name);
            return StatusCode(StatusCodes.Status200OK, samples);
        }

        // POST api/Samples
        [HttpPost]
        public IActionResult Post([FromBody] string dto)
        {
            return StatusCode(StatusCodes.Status200OK);
        }

    }
}
