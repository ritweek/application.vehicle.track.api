using application.vehicle.track.model.Models;
using Microsoft.EntityFrameworkCore;

namespace application.vehicle.track.domain.Data
{
    public partial class VehicleContext: DbContext
    {
        public VehicleContext() { }

        public VehicleContext(DbContextOptions<VehicleContext> options) : base(options) { }

        public DbSet<Registration> Registration { get; set; }
        public DbSet<VehiclePosition> VehiclePosition { get; set; }

    }
}
