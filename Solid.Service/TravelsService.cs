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
    public class TravelsService : ITravelsService
    {
        private readonly ITravelsRepository _travelsService;
        public TravelsService(ITravelsRepository travelsService)
        {
            _travelsService = travelsService;
        }

        public List<Travels> GetAll()
        {
            return _travelsService.GetAll();
        }

        public Travels GetById(int id)
        {
            var travel = _travelsService.GetById(id);
            return travel;
        }
        public Travels Add(Travels value)
        {
            int id;
            if (_travelsService.GetAll().Count() == 0)
            {
                id = 12345;
            }
            else
                id = _travelsService.GetAll().Last<Travels>().Id + 1;
            value.Id = id;
            return _travelsService.Add(value);
        }

        public Travels Update(int id, Travels value)
        {
            if (_travelsService.GetAll().Find(c => c.Id == id) == null)
            {
                return null;
            }
            return _travelsService.Update(id, value);
        }
        public Travels Delete(int id)
        {
            if (_travelsService.GetAll().Find(c => c.Id == id) == null)
            {
                return null;
            }
            return _travelsService.Delete(id);
        }
    }
}
