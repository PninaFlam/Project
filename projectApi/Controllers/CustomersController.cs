using Microsoft.AspNetCore.Mvc;
using Solid.Core.Entities;
using Solid.Core.Services;
using Solid.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SolidApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService _customersService;

        public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_customersService.GetAll());
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cust = _customersService.GetById(id);

            if(cust == null)
                return NotFound();

            return Ok(cust);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public IActionResult Post([FromBody] Customers value)
        {
            return Ok( _customersService.Add(value));
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customers value)
        {
            var cust = _customersService.Update(id, value);

            if (cust == null)
                return NotFound();

           return Ok(cust);
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cust = _customersService.Delete(id);

            if (cust == null)
                return NotFound();

            return Ok(cust);
        }
    }
}
