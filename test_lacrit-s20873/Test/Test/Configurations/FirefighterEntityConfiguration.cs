using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Configurations
{
    public class FirefighterEntityConfiguration : IEntityTypeConfiguration<Firefighter>
    {
        public void Configure(EntityTypeBuilder<Firefighter> builder)
        {
            builder.ToTable("Firefighter");

            builder.HasKey(e => e.IdFirefighter);
            builder.Property(e => e.IdFirefighter).ValueGeneratedOnAdd();

            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(50);
        }
    }
}
