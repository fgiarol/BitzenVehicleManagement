using BitzenVehicleManagementAPI.Models;
using BitzenVehicleManagementAPI.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public long UserId { get; set; }
    }
}
