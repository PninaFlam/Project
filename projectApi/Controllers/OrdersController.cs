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
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;
        private readonly IMapper _mapper;


        public OrdersController(IOrdersService ordersService,IMapper mapper)
        {
            _ordersService = ordersService;
            _mapper = mapper;
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

            var orderDto=_mapper.Map<OrdersDto>(order);

           return Ok(orderDto);
        }


        // POST api/<ParkingsController>
        [HttpPost]
        public IActionResult Post([FromBody] OrdersModel value)
        {
            var orderModel = new Orders { NumOfPlaces = value.NumOfPlaces, CustomersId = value.CustomersId, TravelsId = value.TravelsId };
            var order = _ordersService.Add(orderModel);

            var orderDto = _mapper.Map<OrdersDto>(order);

            return Ok(orderDto);
        }


        // PUT api/<ParkingsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Orders value)
        {
            var order = _ordersService.Update(id, value);

            if (order == null)
                return NotFound();

            var orderDto = _mapper.Map<OrdersDto>(order);

            return Ok(orderDto);
        }


        // DELETE api/<ParkingsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var order = _ordersService.Delete(id);

            if (order == null)
                return NotFound();

            var orderDto = _mapper.Map<OrdersDto>(order);

            return Ok(orderDto);
        }
    }
}
