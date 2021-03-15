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
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository _repo;

        public AppointmentController(IAppointmentRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<AppointmentController>
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

        // GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var user = _repo.Get(id);
                if (user == null)
                {
                    return NotFound("Appointment not found");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<AppointmentController>
        [HttpPost]
        public IActionResult Post([FromBody] Appointment appointment)
        {
            try
            {
                if (appointment.Scheduledtime == null
                    || appointment.Professional == null
                    || appointment.Client == null
                    || appointment.Service == null)
                {
                    return BadRequest("You must provide all of the fields [Scheduledtime, Professional, Client, Service]");
                }
                _repo.Add(appointment);
                return Ok("Appointment successfully Added");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Appointment appointmentDto)
        {
            try
            {
                var appointment = _repo.Get(id);
                if (appointment == null)
                {
                    return NotFound("Appointment not found");
                }
                if (appointmentDto.Scheduledtime == null
                    || appointmentDto.Professional == null
                    || appointmentDto.Client == null
                    || appointmentDto.Service == null)
                {
                    return BadRequest("You must provide all of the fields [Scheduledtime, Professional, Client, Service]");
                }
                _repo.Update(appointmentDto);
                return Ok("Appointment successfully Updated");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var appointment = _repo.Get(id);
                if (appointment == null)
                {
                    return NotFound("Appointment not found");
                }
                _repo.Remove(appointment);
                return Ok("Appointment removed successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
