using IOTLabWebApi.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace IOTLabWebApi.Persistence
{
    public class IotLabDbContext:DbContext
    {   
        public DbSet<Device> Devices { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<UserAppProfile> UserAppProfiles { get; set; }
        public IotLabDbContext(DbContextOptions<IotLabDbContext> options )
        :base(options)
        {

        }
    }
}   