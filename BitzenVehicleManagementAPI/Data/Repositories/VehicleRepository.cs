using BitzenVehicleManagementAPI.Models;
using BitzenVehicleManagementAPI.Models.Repositories;

namespace BitzenVehicleManagementAPI.Data.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly BitzenApplicationContext _context;

        public VehicleRepository(BitzenApplicationContext context)
        {
            _context = context;
        }
        public Vehicle Create(Vehicle vehicle)
        {
            _context.Add(vehicle);
            _context.SaveChanges();

            return vehicle;
        }

        public void Delete(Vehicle vehicle)
        {
            _context.Remove(vehicle);
            _context.SaveChanges();
        }

        public Vehicle Get(long vehicleId)
        {
            return _context.Vehicles.Find(vehicleId);
        }

        public Vehicle Update(Vehicle vehicle)
        {
            _context.Update(vehicle);
            _context.SaveChanges();

            return vehicle;
        }
    }
}
