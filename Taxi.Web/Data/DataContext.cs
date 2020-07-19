using Microsoft.EntityFrameworkCore;
using Taxi.Web.Data.Mapping;
using Taxi.Web.Models;

namespace Taxi.Web.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Taxis> Taxis { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<TripDetail> TripDetails { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TaxisMap());
            modelBuilder.ApplyConfiguration(new TripMap());
            modelBuilder.ApplyConfiguration(new TripDetailMap());

        }
    }
}
