using BitzenVehicleManagementAPI.Models.Enums;
using System;

namespace BitzenVehicleManagementAPI.DTOs
{
    public class FuelingDto
    {
        public decimal FuelingMileage { get; set; }
        public decimal Liters { get; set; }
        public decimal Value { get; set; }
        public DateTime FuelingDateTime { get; set; }
        public string FuelStation { get; set; }
        public FuelType FuelType { get; set; }
        public long VehicleId { get; set; }
    }
}
