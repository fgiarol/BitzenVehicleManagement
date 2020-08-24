using System;

namespace BitzenVehicleManagementAPI.DTOs
{
    public class UserTokenDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
