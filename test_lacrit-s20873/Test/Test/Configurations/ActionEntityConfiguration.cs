using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Configurations
{
    public class ActionEntityConfiguration : IEntityTypeConfiguration<Action>
    {
        public void Configure(EntityTypeBuilder<Action> builder)
        {
            builder.ToTable("Action");

            builder.HasKey(e => e.IdAction);
            builder.Property(e => e.IdAction).ValueGeneratedOnAdd();

            builder.Property(e => e.StartTime).IsRequired().HasColumnType("datetime"); ;
            builder.Property(e => e.EndTime).HasColumnType("datetime"); 
            builder.Property(e => e.NeedSpecialEquipment).IsRequired().HasColumnType("bit");
        }
    }
}
