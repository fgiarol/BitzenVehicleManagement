using BitzenVehicleManagementAPI.Models.Enums;

namespace BitzenVehicleManagementAPI.DTOs
{
    public class VehicleDto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Plate { get; set; }
        public VehicleType VehicleType { get; set; }
        public FuelType FuelType { get; set; }
        public decimal Mileage { get; set; }
        public string Picture { get; set; }
    }
}
