namespace BitzenVehicleManagementAPI.Models.Repositories
{
    public interface IFuelingRepository
    {
        Fueling Create(Fueling fueling);
        Fueling Get(long fuelingId);
        void Delete(Fueling fueling);
        Fueling Update(Fueling fueling);
    }
}
