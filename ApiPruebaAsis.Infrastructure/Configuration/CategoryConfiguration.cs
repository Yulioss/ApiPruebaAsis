using ApiPruebaAsis.Domain.Entitites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace ApiPruebaAsis.Infrastructure.Configguratioon
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(c => c.CategoryId);

            builder.Property(c => c.CategoryName)
                   .HasMaxLength(15)
                   .IsRequired();

            builder.Property(c => c.Description)
                   .HasMaxLength(500);

            builder.Property(c => c.Picture)
                   .HasMaxLength(500);
        }
    }
}
