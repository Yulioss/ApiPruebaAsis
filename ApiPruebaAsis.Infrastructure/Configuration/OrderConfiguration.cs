using ApiPruebaAsis.Domain.Entitites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace ApiPruebaAsis.Infrastructure.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.OrderId);

            builder.Property(x => x.Freight)
                   .HasColumnType("decimal(18,2)");

            builder.Property(x => x.ShipName).HasMaxLength(40);
            builder.Property(x => x.ShipAddress).HasMaxLength(60);
            builder.Property(x => x.ShipCity).HasMaxLength(15);
            builder.Property(x => x.ShipRegion).HasMaxLength(15);
            builder.Property(x => x.ShipPostalCode).HasMaxLength(10);
            builder.Property(x => x.ShipCountry).HasMaxLength(15);

            builder.HasOne(x => x.Customer)
                   .WithMany(c => c.Orders)
                   .HasForeignKey(x => x.CustomerId);

            builder.HasOne(x => x.Employee)
                   .WithMany(e => e.Orders)
                   .HasForeignKey(x => x.EmployeeId);

            builder.HasOne(x => x.Shipper)
                   .WithMany(s => s.Orders)
                   .HasForeignKey(x => x.ShipVia);
        }
    }
}
