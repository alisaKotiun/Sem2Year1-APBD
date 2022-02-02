using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial8.Models;

namespace Tutorial8.Configurations
{
    public class PrescriptionMedicamentEntityTypeConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
    {
        public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
        {
            builder.ToTable("Prescription_Medicament");

            builder.HasKey(e => new { e.IdMedicament, e.IdPrescription });

            builder.Property(e => e.Dose);
            builder.Property(e => e.Details).IsRequired().HasMaxLength(100);

            builder.HasOne(e => e.Medicament)
                .WithMany(m => m.PrescriptionMedicaments)
                .HasForeignKey(m => m.IdMedicament)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(e => e.Prescription)
                .WithMany(p => p.PrescriptionMedicaments)
                .HasForeignKey(p => p.IdPrescription)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
