using Microsoft.AspNetCore.Mvc;
using Salao_Marcelo.Data.Interfaces;
using Salao_Marcelo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Salao_Marcelo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _repo;

        public ClientController(IClientRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<ClientController>
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

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var client = _repo.Get(id);
                if (client == null)
                {
                    return NotFound("Client not found");
                }
                return Ok(client);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<ClientController>
        [HttpPost]
        public IActionResult Post([FromBody] Client client)
        {
            try
            {
                if (client.Name == null || client.Phone == null || client.Address == null)
                {
                    return BadRequest("You must provide all of the fields [Name, Phone, Address]");
                }
                _repo.Add(client);
                return Ok("Client successfully added");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Client clientDto)
        {
            try
            {
                var client = _repo.Get(id);
                if (client == null)
                {
                    return NotFound("Client not found");
                }
                if (clientDto.Name == null || clientDto.Phone == null || clientDto.Address == null)
                {
                    return BadRequest("You must provide all of the fields [Name, Phone, Address]");
                }
                _repo.Update(clientDto);
                return Ok("Client successfully updated");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var client = _repo.Get(id);
                if (client == null)
                {
                    return NotFound("Client not found");
                }
                _repo.Remove(client);
                return Ok("Client successfully removed");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
