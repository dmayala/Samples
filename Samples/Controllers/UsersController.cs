using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Samples.Core.Repositories;

namespace Samples.Controllers
{
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly ISamplesAppRepository _repository;

        public UsersController(ISamplesAppRepository repository)
        {
            _repository = repository;
        }

        // GET api/Users
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var users = _repository.GetUsers();
                return StatusCode(StatusCodes.Status200OK, users);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}