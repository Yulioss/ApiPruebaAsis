using ApiPruebaAsis.Domain.Entitites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace ApiPruebaAsis.Infrastructure.Configuration
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers");

            builder.HasKey(x => x.SupplierId);

            builder.Property(x => x.CompanyName)
                   .HasMaxLength(40)
                   .IsRequired();

            builder.Property(x => x.ContactName).HasMaxLength(30);
            builder.Property(x => x.ContactTitle).HasMaxLength(30);
            builder.Property(x => x.Address).HasMaxLength(60);
            builder.Property(x => x.City).HasMaxLength(15);
            builder.Property(x => x.Region).HasMaxLength(15);
            builder.Property(x => x.PostalCode).HasMaxLength(10);
            builder.Property(x => x.Country).HasMaxLength(15);
            builder.Property(x => x.Phone).HasMaxLength(24);
            builder.Property(x => x.Fax).HasMaxLength(24);
        }
    }
}
