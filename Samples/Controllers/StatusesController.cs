using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Samples.Core.Dtos;
using Samples.Core.Repositories;

namespace Samples.Controllers
{
    [Route("api/[controller]")]
    public class StatusesController : Controller
    {
        private readonly ISamplesAppRepository _repository;

        public StatusesController(ISamplesAppRepository repository)
        {
            _repository = repository;
        }

        // GET api/Statuses
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var statuses = _repository.GetStatuses();
                return StatusCode(StatusCodes.Status200OK, new ResultBodyDto
                {
                    Status = "success",
                    Data = statuses,
                    Message = ""
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResultBodyDto
                {
                    Status = "error",
                    Data = null,
                    Message = "Failed to retrieve statuses."
                });
            }
        }
    }
}
