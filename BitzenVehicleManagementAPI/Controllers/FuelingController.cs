using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BitzenVehicleManagementAPI.Models;
using BitzenVehicleManagementAPI.Models.Repositories;
using BitzenVehicleManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BitzenVehicleManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelingController : ControllerBase
    {
        private readonly FuelingService _fuelingService;

        public FuelingController(FuelingService fuelingService)
        {
            _fuelingService = fuelingService;
        }

        // GET: api/<FuelingController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FuelingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FuelingController>
        [HttpPost]
        public IActionResult Post([FromBody] Fueling fueling)
        {
            //fueling.UserId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            fueling.UserId = 2;
            _fuelingService.Create(fueling);

            return Ok(fueling);
        }

        // PUT api/<FuelingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FuelingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
