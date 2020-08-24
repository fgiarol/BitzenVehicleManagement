using BitzenVehicleManagementAPI.Extensions;
using BitzenVehicleManagementAPI.Models;
using BitzenVehicleManagementAPI.Models.Repositories;
using BitzenVehicleManagementAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BitzenVehicleManagementAPI.Services
{
    public class FuelingService : IFuelingService
    {
        private readonly IFuelingRepository _repo;
        private readonly IVehicleRepository _vehicleRepo;
        private readonly IUser _user;

        public FuelingService(IFuelingRepository repo, IVehicleRepository vehicleRepo, IUser user)
        {
            _repo = repo;
            _vehicleRepo = vehicleRepo;
            _user = user;
        }

        public Fueling Create(Fueling fueling)
        {
            if (fueling == null)
                throw new ArgumentException("Fueling cannot be null");

            if (fueling.FuelingId != 0)
                throw new ArgumentException("Create cannot have FuelingId");

            if (_vehicleRepo.Find(fueling.VehicleId) == null)
                throw new ArgumentException("Vehicle does not exists");

            return _repo.Create(fueling);
        }

        public Fueling Get(long fuelingId)
        {
            if (fuelingId < 1)
                throw new ArgumentException($"FuelingId cannot be {fuelingId}");

            var fueling = _repo.Find(fuelingId);

            if (fueling == null)
                throw new ArgumentException("Fueling does not exists");

            if (fueling.UserId != _user.GetUserId())
                throw new ArgumentException($"UserId: {_user.GetUserId()} - does not have permission");

            return fueling;
        }

        public List<Fueling> GetAll()
        {
            var userId = _user.GetUserId();
            var fuelings = _repo.FindAll(uid => uid.UserId == userId).ToList();

            return fuelings ?? throw new ArgumentException($"UserId: {userId} - does not have Fuelings registered");
        }

        public void Delete(long fuelingId)
        {
            var fueling = Get(fuelingId);
            _repo.Delete(fueling);
        }

        public Fueling Update(Fueling fueling)
        {
            return _repo.Update(fueling);
        }
    }
}
