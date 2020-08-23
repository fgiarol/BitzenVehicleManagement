namespace BitzenVehicleManagementAPI.Models.Repositories
{
    public interface IVehicleRepository
    {
        Vehicle Create(Vehicle vehicle);
        Vehicle Get(long vehicleId);
        void Delete(Vehicle vehicle);
        Vehicle Update(Vehicle vehicle);
    }
}
