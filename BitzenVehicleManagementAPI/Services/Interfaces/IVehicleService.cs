using BitzenVehicleManagementAPI.Models;
using System.Collections.Generic;

namespace BitzenVehicleManagementAPI.Services.Interfaces
{
    public interface IVehicleService
    {
        Vehicle Create(Vehicle vehicle);
        void Delete(long vehicleId);
        Vehicle Get(long vehicleId);
        List<Vehicle> GetAll();
        Vehicle Update(Vehicle vehicle);
    }
}