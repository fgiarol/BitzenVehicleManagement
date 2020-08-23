using BitzenVehicleManagementAPI.Models;
using BitzenVehicleManagementAPI.Models.Repositories;

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

        public Fueling Get(long fuelingId)
        {
            return _context.Fuelings.Find(fuelingId);
        }

        public Fueling Update(Fueling fueling)
        {
            _context.Update(fueling);
            _context.SaveChanges();

            return fueling;
        }
    }
}
