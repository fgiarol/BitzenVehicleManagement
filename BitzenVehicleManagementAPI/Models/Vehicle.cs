using BitzenVehicleManagementAPI.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace BitzenVehicleManagementAPI.Models
{
    public class Vehicle
    {
        public long VehicleId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Plate { get; set; }
        public VehicleType VehicleType { get; set; }
        public FuelType FuelType { get; set; }
        public decimal Mileage { get; set; }
        public User User { get; set; }
        public string Picture { get; set; }
        public long UserId { get; set; }
    }
}
