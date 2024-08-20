using dentalApi.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace dentalApi.Database
{
    public class DentalContext : DbContext
    {
        public DentalContext(DbContextOptions<DentalContext> options)
        : base(options)
        {

        }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
