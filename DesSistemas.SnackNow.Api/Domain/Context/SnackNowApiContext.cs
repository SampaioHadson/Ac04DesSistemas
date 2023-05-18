using DesSistemas.SnackNow.Api.Domain.Context.Mappings;
using DesSistemas.SnackNow.Api.Domain.Entities;
using DesSistemas.SnackNow.Startup.ApiLayers.Database;
using Microsoft.EntityFrameworkCore;

namespace DesSistemas.SnackNow.Api.Domain.Context
{
    public class SnackNowApiContext : DbContextBase
    {
        public DbSet<UserSystem> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Establishment> Establishments { get; set; }
        public DbSet<MessengerMessage> MessengerMessages { get; set; }
        public DbSet<BarEntity> BarEntities { get; set; }
        public DbSet<DonationRequest> DonationRequests { get; set; }
        public DbSet<DonationRequestImage> DonationRequestImages { get; set; }
        public DbSet<Payments> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressMapping());
            modelBuilder.ApplyConfiguration(new EstablishmentMapping());
            modelBuilder.ApplyConfiguration(new IndividualAddressMapping());
            modelBuilder.ApplyConfiguration(new ProductCategoryMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new UserSystemMapping());
            modelBuilder.ApplyConfiguration(new UserSystemPassRecoveryMapping());
            modelBuilder.ApplyConfiguration(new MessengerMessageMapping());
            modelBuilder.ApplyConfiguration(new BarMapping());
            modelBuilder.ApplyConfiguration(new PaymentsMapping());
            modelBuilder.ApplyConfiguration(new DonationRequestImageMapping());
            modelBuilder.ApplyConfiguration(new DonationRequestMapping());
            base.OnModelCreating(modelBuilder);
        }

        public void Migrate()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            Database.Migrate();
        }
    }
}