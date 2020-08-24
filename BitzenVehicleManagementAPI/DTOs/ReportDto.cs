namespace BitzenVehicleManagementAPI.DTOs
{
    public class ReportDto
    {
        public int Month { get; set; }
        public decimal TotalLiters { get; set; }
        public decimal TotalValue { get; set; }
        public decimal TotalMonthMileage { get; set; }
        public decimal AvgMonthMileagePerLiter { get; set; }
        public long VehicleId { get; set; }
        public long UserId { get; set; }
    }
}