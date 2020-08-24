using BitzenVehicleManagementAPI.Extensions;
using BitzenVehicleManagementAPI.Models;
using BitzenVehicleManagementAPI.Models.Repositories;
using BitzenVehicleManagementAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BitzenVehicleManagementAPI.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _repo;
        private readonly IUser _user;

        public VehicleService(IVehicleRepository repo, IUser user)
        {
            _repo = repo;
            _user = user;
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

            var vehicle = _repo.Find(vehicleId);

            if (vehicle == null)
                throw new ArgumentException("Vehicle does not exists");

            if (vehicle.UserId != _user.GetUserId())
                throw new ArgumentException($"UserId: {_user.GetUserId()} - does not have permission");

            return vehicle;
        }

        public List<Vehicle> GetAll()
        {
            var userId = _user.GetUserId();
            var vehicles = _repo.FindAll(uid => uid.UserId == userId).ToList();

            return vehicles ?? throw new ArgumentException($"UserId: {userId} - does not have Vehicles registered");
        }

        public void Delete(long vehicleId)
        {
            var vehicle = Get(vehicleId);
            _repo.Delete(vehicle);
        }

        public Vehicle Update(Vehicle vehicle)
        {
            return _repo.Update(vehicle);
        }
    }
}
