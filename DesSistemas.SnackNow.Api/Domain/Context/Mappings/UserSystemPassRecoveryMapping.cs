using DesSistemas.SnackNow.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DesSistemas.SnackNow.Api.Domain.Context.Mappings
{
    public class UserSystemPassRecoveryMapping : IEntityTypeConfiguration<UserSystemPassRecovery>
    {
        public void Configure(EntityTypeBuilder<UserSystemPassRecovery> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);
        }
    }
}
