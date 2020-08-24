using BitzenVehicleManagementAPI.Models;
using System.Collections.Generic;

namespace BitzenVehicleManagementAPI.Services.Interfaces
{
    public interface IFuelingService
    {
        Fueling Create(Fueling fueling);
        void Delete(long fuelingId);
        Fueling Get(long fuelingId);
        List<Fueling> GetAll();
        Fueling Update(Fueling fueling);
    }
}