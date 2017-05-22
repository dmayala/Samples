using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Samples.Core.Dtos;
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
                return StatusCode(StatusCodes.Status200OK, new ResultBodyDto
                {
                    Status = "success",
                    Data = samples,
                    Message = ""
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResultBodyDto
                {
                    Status = "error",
                    Data = null,
                    Message = "Failed to retrieve samples."
                });
            }
        }

        // POST api/Samples
        [HttpPost]
        public IActionResult Post([FromBody] AddSampleDto sample)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, new ResultBodyDto
                {
                    Status = "error",
                    Data = null,
                    Message = "The model state was invalid."
                });

            try
            {
                _repository.AddSample(new Sample {
                    Barcode = sample.Barcode,
                    CreatedBy = sample.CreatedBy.Value,
                    StatusId = sample.StatusId.Value
                });
                _repository.SaveAll();
                return StatusCode(StatusCodes.Status200OK, new ResultBodyDto
                {
                    Status  = "success",
                    Data = {},
                    Message = "" 
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResultBodyDto
                {
                    Status = "error",
                    Data = null,
                    Message = "Could not save this sample."
                });
            }
       
        }

    }
}
