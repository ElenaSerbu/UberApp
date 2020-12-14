using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UberApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //public DbSet<UserWatchlist> UserWatchlist { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<Trip> Trip { get; set; }
        //public DbSet<PaymentTrip> PaymentTrip { get; set; }
        //public DbSet<Payment> Payment { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
