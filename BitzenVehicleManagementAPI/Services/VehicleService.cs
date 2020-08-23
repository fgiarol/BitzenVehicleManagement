using BitzenVehicleManagementAPI.Models;
using BitzenVehicleManagementAPI.Models.Repositories;
using System;

namespace BitzenVehicleManagementAPI.Services
{
    public class VehicleService
    {
        private readonly IVehicleRepository _repo;

        public VehicleService(IVehicleRepository repo)
        {
            _repo = repo;
        }

        public Vehicle Create(Vehicle vehicle)
        {
            if (vehicle == null)
                throw new ArgumentException("Vehicle cannot be null");

            if (vehicle.VehicleId != 0)
                throw new ArgumentException("Create cannot have VehicleId");

            return _repo.Create(vehicle);
        }

        public Vehicle Get(long vehicleId)
        {
            if (vehicleId < 1)
                throw new ArgumentException($"VehicleId cannot be {vehicleId}");

            return _repo.Get(vehicleId);
        }

        public void Delete(long vehicleId)
        {
            var vehicle = Get(vehicleId);
            _repo.Delete(vehicle);
        }

        public Vehicle Update(Vehicle vehicle)
        {
            if (vehicle == null)
                throw new ArgumentException("Vehicle cannot be null");

            if (Get(vehicle.VehicleId) == null)
                throw new ArgumentException("Vehicle does not exists");

            return _repo.Update(vehicle);
        }

        //TODO: implement validations
    }
}
