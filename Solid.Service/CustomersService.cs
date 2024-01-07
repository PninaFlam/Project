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
    public class CustomersService:ICustomersService
    {
        private readonly ICustomersRepository _customersService;
        public CustomersService(ICustomersRepository customersService)
        {
            _customersService = customersService;
        }

        public List<Customers> GetAll()
        {
            return _customersService.GetAll();
        }

        public Customers GetById(int id)
        {
            var customer = _customersService.GetById(id);
            return customer;
        }
        public Customers Add(Customers value)
        {
            return _customersService.Add(value);
        }

        public Customers Update(int id, Customers value)
        {
            if (_customersService.GetAll().Find(c => c.Id == id) == null)
            {
                return null;
            }
            return _customersService.Update(id, value);
        }
        public Customers Delete(int id)
        {
            if (_customersService.GetAll().Find(c => c.Id == id) == null)
            {
                return null;
            }
            return _customersService.Delete(id);
        }
    }
}
