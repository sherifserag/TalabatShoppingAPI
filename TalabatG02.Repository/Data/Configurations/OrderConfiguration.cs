using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatG02.Core.Entities.Order_Aggregation;

namespace TalabatG02.Repository.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(O => O.ShipToAddress, ShippingAddress => ShippingAddress.WithOwner());//1 TO 1 total 

            builder.Property(O => O.Status)
                   .HasConversion(
                     OS => OS.ToString(),
                     OS => (OrderState)Enum.Parse(typeof(OrderState), OS));

            builder.Property(O => O.SubTotal)
                   .HasColumnType("decimal(18,2)");

            builder.HasOne(O => O.DeliveryMethod)
                   .WithMany()
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
