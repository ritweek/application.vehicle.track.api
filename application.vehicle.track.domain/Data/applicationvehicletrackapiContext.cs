using Microsoft.EntityFrameworkCore;
using application.vehicle.track.model.Models;

namespace application.vehicle.track.api.Data
{
    public class applicationvehicletrackapiContext : DbContext
    {
        public applicationvehicletrackapiContext (DbContextOptions<applicationvehicletrackapiContext> options)
            : base(options)
        {
        }

        public DbSet<Registration> Registration { get; set; }
    }
}
