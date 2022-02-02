using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Configurations
{
    public class FireTruckEntityConfiguration : IEntityTypeConfiguration<FireTruck>
    {
        public void Configure(EntityTypeBuilder<FireTruck> builder)
        {
            builder.ToTable("FireTruck");

            builder.HasKey(e => e.IdFireTruck);
            builder.Property(e => e.IdFireTruck).ValueGeneratedOnAdd();

            builder.Property(e => e.OperationalNumber).IsRequired().HasMaxLength(10);
            builder.Property(e => e.SpecialEquipment).IsRequired().HasColumnType("bit");
        }
    }
}
