using BitzenVehicleManagementAPI.Models;
using BitzenVehicleManagementAPI.Models.Repositories;
using System;

namespace BitzenVehicleManagementAPI.Services
{
    public class FuelingService
    {
        private readonly IFuelingRepository _repo;

        public FuelingService(IFuelingRepository repo)
        {
            _repo = repo;
        }

        public Fueling Create(Fueling fueling)
        {
            if (fueling == null)
                throw new ArgumentException("Fueling cannot be null");

            if (fueling.FuelingId > 0)
                throw new ArgumentException("Create cannot have FuelingId");

            return _repo.Create(fueling);
        }

        public Fueling Get(long fuelingId)
        {
            if (fuelingId < 1)
                throw new ArgumentException($"FuelingId cannot be {fuelingId}");

            return _repo.Get(fuelingId);
        }

        public void Delete(long fuelingId)
        {
            var fueling = Get(fuelingId);
            _repo.Delete(fueling);
        }

        public Fueling Update(Fueling fueling)
        {
            if (fueling == null)
                throw new ArgumentException("Fueling cannot be null");

            if (Get(fueling.FuelingId) == null)
                throw new ArgumentException("Fueling does not exists");

            return _repo.Update(fueling);
        }

        //TODO: implement validations
    }
}
