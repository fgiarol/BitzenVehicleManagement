using BitzenVehicleManagementAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BitzenVehicleManagementAPI.Data
{
    public class BitzenApplicationContext : IdentityDbContext<User, IdentityRole<long>, long>
    {
        public BitzenApplicationContext(DbContextOptions<BitzenApplicationContext> options) 
            : base(options)
        {

        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Fueling> Fuelings { get; set; }
    }
}
