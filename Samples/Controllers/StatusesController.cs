using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                return StatusCode(StatusCodes.Status200OK, statuses);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
