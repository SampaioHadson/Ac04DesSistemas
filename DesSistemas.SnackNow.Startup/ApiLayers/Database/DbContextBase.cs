using DesSistemas.SnackNow.Startup.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DesSistemas.SnackNow.Startup.ApiLayers.Database
{
    public abstract class DbContextBase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DbConnection.ConnectionDatabase = "";
            if (optionsBuilder.IsConfigured)
                return;

            if (!string.IsNullOrEmpty(DbConnection.ConnectionDatabase))
            {
                optionsBuilder.UseNpgsql(DbConnection.ConnectionDatabase, op =>
                {
                    op.EnableRetryOnFailure();
                });
            }
            else
            {
                optionsBuilder.UseInMemoryDatabase("InMemoryDb", op =>
                {
                    op.EnableNullChecks();
                });
            }
        }
    }
}