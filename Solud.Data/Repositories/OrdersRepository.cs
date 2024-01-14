using Microsoft.EntityFrameworkCore;
using Solid.Core.Entities;
using Solid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Data.Repositories
{
    public class OrdersRepository:IOrdersRepository
    {
        private readonly DataContext _context;
        public OrdersRepository(DataContext context)
        {
            _context = context;
        }

        public List<Orders> GetAll()
        {
            return _context.Orders.Include(c=>c.Customer).ToList();
        }

        public Orders GetById(int id)
        {
            var order = _context.Orders.Include(c => c.Travels).Include(c => c.Customer).ToList().Find(c => c.Id == id);
            return order;
        }
        public Orders Add(Orders value)
        {
            _context.Orders.Add(value);

            _context.SaveChanges();

            return value;
        }

        public Orders Update(int id, Orders value)
        {
            var orderToUpdate = _context.Orders.ToList().Find(p => p.Id == id);

            if (orderToUpdate == null)
                return null;

            orderToUpdate.NumOfPlaces = value.NumOfPlaces;
            orderToUpdate.Travels = value.Travels;
            //orderToUpdate.Customer = value.Customer;

            _context.SaveChanges();

            return orderToUpdate;
        }
        public Orders Delete(int id)
        {
            var order = _context.Orders.ToList().Find(p => p.Id == id);

            if (order == null)
                return null;

            _context.Orders.Remove(order);
            _context.SaveChanges();

            return order;
        }
    }
}
