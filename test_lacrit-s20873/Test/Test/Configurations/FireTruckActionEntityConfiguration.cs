using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Configurations
{
    public class FireTruckActionEntityConfiguration : IEntityTypeConfiguration<FireTruckAction>
    {
        public void Configure(EntityTypeBuilder<FireTruckAction> builder)
        {
            builder.ToTable("FireTruck_Action");

            builder.HasKey(e => e.IdFireTruckAction);
            builder.Property(e => e.IdFireTruckAction).ValueGeneratedOnAdd();

            builder.Property(e => e.AssignmentDate).IsRequired().HasColumnType("datetime");

            builder.HasOne(e => e.Action)
                .WithMany(p => p.FireTruckActions)
                .HasForeignKey(p => p.IdAction);

            builder.HasOne(e => e.FireTruck)
                .WithMany(d => d.FireTruckActions)
                .HasForeignKey(d => d.IdFireTruck);
        }
    }
}
