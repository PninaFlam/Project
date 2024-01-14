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
    public class CarsRepository:ITravelsRepository
    {
        private readonly DataContext _context;
        public CarsRepository(DataContext context)
        {
            _context = context;
        }

        public List<Travels> GetAll()
        {
            return _context.Travels.Include(c => c.Orders).ToList();
        }

        public Travels GetById(int id)
        {
            var travel = _context.Travels.Include(c => c.Orders).ToList().Find(c => c.Id == id);
            return travel;
        }
        public Travels Add(Travels value)
        {
            _context.Travels.Add(value);
            _context.SaveChanges();
            return value;
        }

        public Travels Update(int id, Travels value)
        {
            var travelToUpdate = _context.Travels.ToList().Find(c => c.Id ==id);

            if (travelToUpdate == null)
                return null;

            travelToUpdate.Destination = value.Destination;
            travelToUpdate.Date = value.Date;

            _context.SaveChanges();

            return travelToUpdate;
        }
        public Travels Delete(int id)
        {
            var car = _context.Travels.ToList().Find(c => c.Id == id);

            if (car == null)
                return null;
            _context.Travels.Remove(car);
            _context.SaveChanges();
            return car;
        }
    }
}
