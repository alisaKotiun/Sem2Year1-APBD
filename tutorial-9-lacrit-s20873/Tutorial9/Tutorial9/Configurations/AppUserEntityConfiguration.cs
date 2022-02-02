using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial9.Models;

namespace Tutorial9.Configurations
{
    public class AppUserEntityConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUser");

            builder.HasKey(e => e.IdUser);
            builder.Property(e => e.IdUser).ValueGeneratedOnAdd();

            builder.Property(e => e.Login).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Password).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Salt).IsRequired().HasMaxLength(100);
            builder.Property(e => e.RefreshToken).IsRequired().HasMaxLength(100);
            builder.Property(e => e.RefreshTokenExp).HasColumnType("datetime");
        }
    }
}
