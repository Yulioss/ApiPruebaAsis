using ApiPruebaAsis.Domain.Entitites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace ApiPruebaAsis.Infrastructure.Configuration
{
    public class ShipperConfiguration : IEntityTypeConfiguration<Shipper>
    {
        public void Configure(EntityTypeBuilder<Shipper> builder)
        {
            builder.ToTable("Shippers");

            builder.HasKey(x => x.ShipperId);

            builder.Property(x => x.CompanyName)
                   .HasMaxLength(40)
                   .IsRequired();

            builder.Property(x => x.Phone)
                   .HasMaxLength(24);
        }
    }
}
