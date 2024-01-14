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
    public class CustomersRepository : ICustomersRepository
    {
        private readonly DataContext _context;

        public CustomersRepository(DataContext context)
        {
            _context = context;
        }

        public List<Customers> GetAll()
        {
            return _context.Customers.Include(c => c.Orders).ToList();
        }

        public Customers GetById(int id)
        {
            var cust = _context.Customers.Include(c => c.Orders).ToList().Find(c => c.Id == id);
            return cust;
        }
        public Customers Add(Customers value)
        {
            _context.Customers.Add(value);

            _context.SaveChanges();

            return value;
        }

        public Customers Update(int id, Customers value)
        {
            var custToUpdate = _context.Customers.ToList().Find(c => c.Id == id);

            if (custToUpdate == null)
                return null;

            custToUpdate.Name = value.Name;
            custToUpdate.Phone = value.Phone;
            custToUpdate.Password = value.Password;
            custToUpdate.Orders = value.Orders;

            _context.SaveChanges();

            return custToUpdate;
        }
        public Customers Delete(int id)
        {
            var cust = _context.Customers.ToList().Find(c => c.Id == id);

            if (cust == null)
                return null;

            _context.Customers.Remove(cust);
            _context.SaveChanges();

            return cust;
        }
    }
}
