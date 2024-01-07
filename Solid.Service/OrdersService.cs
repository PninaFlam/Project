using Solid.Core.Entities;
using Solid.Core.Repositories;
using Solid.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Service
{
    public class OrdersService:IOrdersService
    {
        private readonly IOrdersRepository _ordersService;
        public OrdersService(IOrdersRepository ordersService)
        {
            _ordersService = ordersService;
        }

        public List<Orders> GetAll()
        {
            return _ordersService.GetAll();
        }

        public Orders GetById(int id)
        {
            var order = _ordersService.GetById(id);
            return order;
        }
        public Orders Add(Orders value)
        {
            int id;
            if (_ordersService.GetAll().Count() == 0)
            {
                id = 100;
            }
            else
                id = _ordersService.GetAll().Last<Orders>().Id + 1;

            value.Id = id;
            return _ordersService.Add(value);
        }

        public Orders Update(int id, Orders value)
        {
            if (_ordersService.GetAll().Find(c => c.Id == id) == null)
            {
                return null;
            }
            return _ordersService.Update(id, value);
        }
        public Orders Delete(int id)
        {
            if (_ordersService.GetAll().Find(c => c.Id == id) == null)
            {
                return null;
            }
            return _ordersService.Delete(id);
        }
    }
}
