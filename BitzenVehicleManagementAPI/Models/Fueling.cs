using BitzenVehicleManagementAPI.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System;

namespace BitzenVehicleManagementAPI.Models
{
    public class Fueling
    {
        public long FuelingId { get; set; }
        public decimal FuelingMileage { get; set; }
        public decimal Liters { get; set; }
        public DateTime FuelingDateTime { get; set; }
        public string FuelStation { get; set; }
        public User User { get; set; }
        public FuelType FuelType { get; set; }
        public Vehicle Vehicle { get; set; }
        public long VehicleId { get; set; }
        public long UserId { get; set; }
    }
}
