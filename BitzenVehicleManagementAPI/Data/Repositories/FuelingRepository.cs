using BitzenVehicleManagementAPI.Models;
using BitzenVehicleManagementAPI.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BitzenVehicleManagementAPI.Data.Repositories
{
    public class FuelingRepository : IFuelingRepository
    {
        private readonly BitzenApplicationContext _context;

        public FuelingRepository(BitzenApplicationContext context)
        {
            _context = context;
        }
        public Fueling Create(Fueling fueling)
        {
            _context.Add(fueling);
            _context.SaveChanges();

            return fueling;
        }

        public void Delete(Fueling fueling)
        {
            _context.Remove(fueling);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public Fueling Find(long fuelingId)
        {
            return _context.Fuelings.Find(fuelingId);
        }

        public IEnumerable<Fueling> FindAll(Expression<Func<Fueling, bool>> predicate)
        {
            return _context.Fuelings.Where(predicate).AsEnumerable();
        }

        public Fueling Update(Fueling fueling)
        {
            _context.Update(fueling);
            _context.SaveChanges();

            return fueling;
        }
    }
}
