using Solid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Repositories
{
    public interface ICustomersRepository
    {
        List<Customers> GetAll();

        Customers GetById(int id);

        Customers Add(Customers value);

        Customers Update(int id, Customers value);

        Customers Delete(int id);
    }
}
