using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BitzenVehicleManagementAPI.Models.Repositories
{
    public interface IVehicleRepository : IDisposable
    {
        Vehicle Create(Vehicle vehicle);
        Vehicle Find(long vehicleId);
        IEnumerable<Vehicle> FindAll(Expression<Func<Vehicle, bool>> predicate);
        void Delete(Vehicle vehicle);
        Vehicle Update(Vehicle vehicle);
    }
}
