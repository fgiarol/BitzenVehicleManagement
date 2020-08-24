using System.Collections.Generic;
using System.Security.Claims;

namespace BitzenVehicleManagementAPI.Extensions
{
    public interface IUser
    {
        string Name { get; }

        IEnumerable<Claim> GetClaimsIdentity();
        string GetUserEmail();
        long GetUserId();
        bool IsAuthenticated();
        bool IsInRole(string role);
    }
}