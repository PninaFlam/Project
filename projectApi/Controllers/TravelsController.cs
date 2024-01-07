using Microsoft.AspNetCore.Mvc;
using Solid.Core.Entities;
using Solid.Core.Services;
using Solid.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SolidApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelsController : ControllerBase
    {
        private readonly ITravelsService _travelsService;

        public TravelsController(ITravelsService travelsService)
        {
            _travelsService = travelsService;
        }

        // GET: api/<CarsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_travelsService.GetAll());
        }


        // GET api/<CarsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var travel = _travelsService.GetById(id);

            if(travel == null)
                return NotFound();

            return Ok(travel);
        }


        // POST api/<CarsController>
        [HttpPost]
        public IActionResult Post([FromBody] Travels value)
        {
            return Ok(_travelsService.Add(value));
        }


        // PUT api/<CarsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Travels value)
        {
            var travel = _travelsService.Update(id, value);

            if (travel == null)
                return NotFound();

           return Ok(travel);
        }


        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var travel = _travelsService.Delete(id);

            if (travel == null)
                return NotFound();

            return Ok(travel);

        }
    }
}
