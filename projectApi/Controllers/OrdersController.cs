using Microsoft.AspNetCore.Mvc;
using Solid.Core.Entities;
using Solid.Core.Services;
using Solid.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SolidApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }


        // GET: api/<ParkingsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_ordersService.GetAll());
        }


        // GET api/<ParkingsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var order = _ordersService.GetById(id);

            if (order == null)
                return NotFound();

           return Ok(order);
        }


        // POST api/<ParkingsController>
        [HttpPost]
        public IActionResult Post([FromBody] Orders value)
        {
            return Ok(_ordersService.Add(value));
        }


        // PUT api/<ParkingsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Orders value)
        {
            var order = _ordersService.Update(id, value);

            if (order == null)
                return NotFound();

           return Ok(order);
        }


        // DELETE api/<ParkingsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var order = _ordersService.Delete(id);

            if (order == null)
                return NotFound();

            return Ok(order);
        }
    }
}
