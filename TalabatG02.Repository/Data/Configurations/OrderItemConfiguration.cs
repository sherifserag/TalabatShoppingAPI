﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatG02.Core.Entities.Order_Aggregation;

namespace TalabatG02.Repository.Data.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.OwnsOne(OI => OI.Product, Product => Product.WithOwner());// 1 to 1 total

            builder.Property(OI => OI.Price)
                   .HasColumnType("decimal(18,2)");
        }
    }
}
