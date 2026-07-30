using ApiPruebaAsis.Domain.Entitites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAsis.Infrastructure.Configuration
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails");

            builder.HasKey(x => new
            {
                x.OrderId,
                x.ProductId
            });

            builder.Property(x => x.UnitPrice)
                   .HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.Order)
                   .WithMany(o => o.OrderDetails)
                   .HasForeignKey(x => x.OrderId);

            builder.HasOne(x => x.Product)
                   .WithMany(p => p.OrderDetails)
                   .HasForeignKey(x => x.ProductId);
        }
    }
}
