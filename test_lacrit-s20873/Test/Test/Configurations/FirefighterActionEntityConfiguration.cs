using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Configurations
{
    public class FirefighterActionEntityConfiguration : IEntityTypeConfiguration<FirefighterAction>
    {
        public void Configure(EntityTypeBuilder<FirefighterAction> builder)
        {
            builder.ToTable("Firefighter_Action");

            builder.HasKey(e => new { e.IdFirefighter, e.IdAction });

            builder.HasOne(e => e.Firefighter)
                .WithMany(m => m.FirefighterActions)
                .HasForeignKey(m => m.IdFirefighter)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Action)
                .WithMany(m => m.FirefighterActions)
                .HasForeignKey(m => m.IdAction)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
