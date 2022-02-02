using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial9.Models;

namespace Tutorial9.Configurations
{
    public class PrescriptionEntityTypeConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.ToTable("Prescription");

            builder.HasKey(e => e.IdPrescription);
            builder.Property(e => e.IdPrescription).ValueGeneratedOnAdd();

            builder.Property(e => e.Date).IsRequired().HasColumnType("datetime");
            builder.Property(e => e.DueDate).IsRequired().HasColumnType("datetime");

            builder.HasOne(e => e.Patient)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(p => p.IdPatient);

            builder.HasOne(e => e.Doctor)
                .WithMany(d => d.Prescriptions)
                .HasForeignKey(d => d.IdDoctor);
        }
    }
}
