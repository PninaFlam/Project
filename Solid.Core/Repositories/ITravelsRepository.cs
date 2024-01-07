using Solid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Repositories
{
    public interface ITravelsRepository
    {
        List<Travels> GetAll();

        Travels GetById(int id);

        Travels Add(Travels value);

        Travels Update(int id,Travels value);

        Travels Delete(int id);

    }
}
