using System;
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
        // Optional Query - api/Samples?status=0&name=Example
        [HttpGet]
        public IActionResult Get([FromQuery] int? status, [FromQuery] string name)
        {
            try
            {
                var samples = _repository.GetSamples(status, name);
                return StatusCode(StatusCodes.Status200OK, samples);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        // POST api/Samples
        [HttpPost]
        public IActionResult Post([FromBody] Sample sample)
        {
            try
            {
                _repository.AddSample(sample);
                _repository.SaveAll();
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
       
        }

    }
}
