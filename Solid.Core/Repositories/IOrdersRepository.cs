using Solid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Repositories
{
    public interface IOrdersRepository
    {
        List<Orders> GetAll();

        Orders GetById(int id);

        Orders Add(Orders value);

        Orders Update(int id, Orders value);

        Orders Delete(int id);
    }
}
