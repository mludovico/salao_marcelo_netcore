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
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _repo;

        public ServiceController(IServiceRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<ServiceController>
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

        // GET api/<ServiceController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var service = _repo.Get(id);
                if (service == null)
                {
                    return NotFound("Service not found");
                }
                return Ok(service);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<ServiceController>
        [HttpPost]
        public IActionResult Post([FromBody] Service service)
        {
            try
            {
                if (service.Name == null || service.TimeInMinutes == 0 || service.Price == 0)
                {
                    return NotFound("You must provide all of the fields [Name, TimeInMinutes, Price]");
                }
                _repo.Add(service);
                return Ok("Service successfully added");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<ServiceController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Service serviceDto)
        {
            try
            {
                var service = _repo.Get(id);
                if (serviceDto == null)
                {
                    return NotFound("Service not found");
                }
                if (serviceDto.Name == null || serviceDto.TimeInMinutes == 0 || serviceDto.Price == 0)
                {
                    return NotFound("You must provide all of the fields [Name, TimeInMinutes, Price]");
                }
                _repo.Update(serviceDto);
                return Ok("Service successfully updated");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<ServiceController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var service = _repo.Get(id);
                if (service == null)
                {
                    return NotFound("Service not found");
                }
                _repo.Remove(service);
                return Ok("Service successfully removed");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
