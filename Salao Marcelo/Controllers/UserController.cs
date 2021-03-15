using Microsoft.AspNetCore.Mvc;
using Salao_Marcelo.Data.Interfaces;
using Salao_Marcelo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Salao_Marcelo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;

        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repo.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var user = _repo.Get(id);
                if (user == null)
                {
                    return NotFound("User not found");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            try
            {
                if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Mail) || string.IsNullOrEmpty(user.Password))
                {
                    return BadRequest("You must provide all of the fields [Name, Mail, Password]");
                }
                _repo.Add(user);
                return Ok("User successfully registered");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User userDto)
        {
            try
            {
                var user = _repo.Get(id);
                if (user == null)
                {
                    return NotFound("User not found");
                }
                if (string.IsNullOrEmpty(userDto.Name) || string.IsNullOrEmpty(userDto.Mail) || string.IsNullOrEmpty(userDto.Password))
                {
                    return BadRequest("You must provide all of the fields [Name, Mail, Password]");
                }
                _repo.Update(userDto);
                return Ok("User successfully updated");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var user = _repo.Get(id);
                if (user == null)
                {
                    return NotFound("User not found");
                }
                _repo.Remove(user);
                return Ok("User successfully removed");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
