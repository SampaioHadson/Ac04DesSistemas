using DesSistemas.SnackNow.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DesSistemas.SnackNow.Api.Domain.Context.Mappings
{
    public class BarMapping : IEntityTypeConfiguration<BarEntity>
    {
        public void Configure(EntityTypeBuilder<BarEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);
        }
    }
}