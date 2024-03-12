using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solid.Api.Models;
using Solid.Core;
using Solid.Core.DTOs;
using Solid.Core.Entities;
using Solid.Core.Services;
using Solid.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SolidApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService _customersService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomersService customersService,IMapper mapper)
        {
            _customersService = customersService;
            _mapper = mapper;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cust = _customersService.GetById(id);

            if(cust == null)
                return NotFound();

            var custDto=_mapper.Map<CustomerDto>(cust);

            return Ok(custDto);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public IActionResult Post([FromBody] CustomerModel value)
        {
            var custModel =new Customers { Name = value.Name ,Password=value.Password,Phone=value.Phone};
            var cust = _customersService.Add(custModel);
            var custDto = _mapper.Map<CustomerDto>(cust);

            return Ok(custDto);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerModel value)
        {
            var custModel = new Customers { Name = value.Name, Password = value.Password, Phone = value.Phone };
            var cust = _customersService.Update(id, custModel);

            if (cust == null)
                return NotFound();

            var custDto = _mapper.Map<CustomerDto>(cust);

            return Ok(custDto);
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cust = _customersService.Delete(id);

            if (cust == null)
                return NotFound();

            var custDto = _mapper.Map<CustomerDto>(cust);

            return Ok(custDto);
        }
    }
}
