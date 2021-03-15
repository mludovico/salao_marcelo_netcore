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
    public class ProfessionalController : ControllerBase
    {
        private readonly IProfessionalRepository _repo;

        public ProfessionalController(IProfessionalRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<ProfessionalController>
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

        // GET api/<ProfessionalController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var professional = _repo.Get(id);
                if (professional == null)
                {
                    return NotFound("Professional not found");
                }
                return Ok(professional);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<ProfessionalController>
        [HttpPost]
        public IActionResult Post([FromBody] Professional professional)
        {
            try
            {
                if (professional.Name == null
                    || professional.Phone == null
                    || professional.Address == null
                    || professional.Commission == 0)
                {
                    return BadRequest("You must provide all of the fields [Name, Phone, Address, Comission]");
                }
                _repo.Add(professional);
                return Ok("Professional successfully added");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<ProfessionalController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Professional professionalDto)
        {
            try
            {
                var professional = _repo.Get(id);
                if (professional == null)
                {
                    return NotFound("Professional not found");
                }
                if (professionalDto.Name == null || professionalDto.Phone == null || professionalDto.Address == null)
                {
                    return BadRequest("You must provide all of the fields [Name, Phone, Address, Comission]");
                }
                _repo.Update(professionalDto);
                return Ok("Professional successfully updated");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<ProfessionalController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var professional = _repo.Get(id);
                if (professional == null)
                {
                    return NotFound("Professional not found");
                }
                _repo.Remove(professional);
                return Ok("Professional successfully removed");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
