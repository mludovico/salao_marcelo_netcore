using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Salao_Marcelo.Data.Interfaces;
using Salao_Marcelo.Services;
using Salao_Marcelo.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Salao_Marcelo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUserRepository _repo;

        public HomeController(IUserRepository repo)
        {
            _repo = repo;
        }

        // POST api/<HomeController>
        [HttpPost("login")]
        public IActionResult Post([FromBody] User userDto)
        {
            try
            {
                if(string.IsNullOrEmpty(userDto.Name) || string.IsNullOrEmpty(userDto.Password))
                {
                    return BadRequest("You must provide a user name and password");
                }
                var user = _repo.GetByNameAndPassword(userDto.Name, userDto.Password);
                if (user == null)
                {
                    return NotFound("Invalid credentials");
                }
                var token = TokenService.GerarToken(user);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
