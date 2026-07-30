using ApiPruebaAsis.Domain.Entitites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace ApiPruebaAsis.Infrastructure.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.ProductId);

            builder.Property(x => x.ProductName)
                   .HasMaxLength(40)
                   .IsRequired();

            builder.Property(x => x.QuantityPerUnit)
                   .HasMaxLength(20);

            builder.Property(x => x.UnitPrice)
                   .HasColumnType("decimal(18,2)");

            builder.Property(x => x.Discontinued)
                   .HasDefaultValue(false);

            builder.HasOne(x => x.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(x => x.CategoryId);

            builder.HasOne(x => x.Supplier)
                   .WithMany(s => s.Products)
                   .HasForeignKey(x => x.SupplierId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
