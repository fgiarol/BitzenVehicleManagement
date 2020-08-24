using BitzenVehicleManagementAPI.Models;
using BitzenVehicleManagementAPI.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        public void Dispose()
        {
            _context?.Dispose();
        }

        public Vehicle Find(long vehicleId)
        {
            return _context.Vehicles.Find(vehicleId);
        }

        public IEnumerable<Vehicle> FindAll(Expression<Func<Vehicle, bool>> predicate)
        {
            return _context.Vehicles.Where(predicate).AsEnumerable();
        }

        public Vehicle Update(Vehicle vehicle)
        {
            _context.Update(vehicle);
            _context.SaveChanges();

            return vehicle;
        }
    }
}
