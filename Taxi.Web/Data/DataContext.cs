using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Taxi.Web.Data.Entities;

namespace Taxi.Web.Data
{
    //IdentityDbContext: Es una herencia mas fuerte que DbContext, incluye todas las tablas necesarias para
    //trabajar ka seguridad integrada, a esto se llama notación diamante, es una clase generica
    //Maneja las tablas de usuario, pero que mis usuarios estan personalizados en el User. 
    public class DataContext : IdentityDbContext<UserEntity>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<TaxiEntity> Taxis { get; set; }

        public DbSet<TripEntity> Trips { get; set; }

        public DbSet<TripDetailEntity> TripDetails { get; set; }

        public DbSet<UserGroupEntity> UserGroups { get; set; }

        public DbSet<UserGroupDetailEntity> UserGroupDetails { get; set; }

        public DbSet<UserGroupRequestEntity> UserGroupRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaxiEntity>()
                .HasIndex(t => t.Plaque)
                .IsUnique();
        }
    }
}
