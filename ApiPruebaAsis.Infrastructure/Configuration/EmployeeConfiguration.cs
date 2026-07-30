using ApiPruebaAsis.Domain.Entitites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebaAsis.Infrastructure.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.HasKey(x => x.EmployeeId);

            builder.Property(x => x.LastName)
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(x => x.FirstName)
                   .HasMaxLength(10)
                   .IsRequired();

            builder.Property(x => x.Title).HasMaxLength(30);
            builder.Property(x => x.TitleOfCourtesy).HasMaxLength(25);
            builder.Property(x => x.Address).HasMaxLength(60);
            builder.Property(x => x.City).HasMaxLength(15);
            builder.Property(x => x.Region).HasMaxLength(15);
            builder.Property(x => x.PostalCode).HasMaxLength(10);
            builder.Property(x => x.Country).HasMaxLength(15);
            builder.Property(x => x.HomePhone).HasMaxLength(24);
            builder.Property(x => x.Extension).HasMaxLength(4);

            builder.HasOne(x => x.Manager)
                   .WithMany(x => x.Subordinates)
                   .HasForeignKey(x => x.ReportsTo)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
