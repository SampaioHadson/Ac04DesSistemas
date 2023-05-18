using DesSistemas.SnackNow.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DesSistemas.SnackNow.Api.Domain.Context.Mappings
{
    public class DonationRequestMapping : IEntityTypeConfiguration<DonationRequest>
    {
        public void Configure(EntityTypeBuilder<DonationRequest> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            builder.HasOne(x => x.DonationRequestImage).WithOne(x => x.DonationRequest).HasForeignKey<DonationRequestImage>(x => x.DonationRequestId);
        }
    }
}
