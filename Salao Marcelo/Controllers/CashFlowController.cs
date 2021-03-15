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
    public class CashFlowController : ControllerBase
    {
        private readonly ICashFlowRepository _repo;

        public CashFlowController(ICashFlowRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<CashFlowController>
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

        // GET api/<CashFlowController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var cashflow = _repo.Get(id);
                if (cashflow == null)
                {
                    return NotFound("Movement not found");
                }
                return Ok(cashflow);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<CashFlowController>
        [HttpPost]
        public IActionResult Post([FromBody] CashFlow cashFlow)
        {
            try
            {
                cashFlow.Timestamp = DateTime.Now;
                _repo.Add(cashFlow);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<CashFlowController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CashFlow cashFlowDto)
        {
            try
            {
                var cashFlow = _repo.Get(id);
                if (cashFlow == null)
                {
                    return NotFound("Movement not found");
                }
                cashFlowDto.Timestamp = DateTime.Now;
                _repo.Update(cashFlowDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
