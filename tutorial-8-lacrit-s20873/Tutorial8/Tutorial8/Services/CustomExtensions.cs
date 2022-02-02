using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Tutorial8.Models;

namespace Tutorial8.Services
{
    public static class CustomExtensions
    {
        public static bool CheckSequences(this Prescription pm, IEnumerable<int> dto)
        {
            var pms = pm.PrescriptionMedicaments
                .Select(p => p.IdMedicament);
            return pms.Count() == dto.Count() && pms.All(i => dto.Contains(i));
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { IdDoctor = 1, FirstName = "John", LastName = "Parker", Email = "parke@gmail.com" },
                new Doctor { IdDoctor = 2, FirstName = "Kate", LastName = "McLorance", Email = "kate123@gmail.com" },
                new Doctor { IdDoctor = 3, FirstName = "Pawel", LastName = "Kowalski", Email = "kowalski@gmail.com" }
                );

            modelBuilder.Entity<Patient>().HasData(
                new Patient { IdPatient = 1, FirstName = "Ann", LastName = "Jo", Birthdate = new DateTime(2002, 6, 1) },
                new Patient { IdPatient = 2, FirstName = "Aleks", LastName = "Tu", Birthdate = new DateTime(2001, 2, 13) },
                new Patient { IdPatient = 3, FirstName = "Ann", LastName = "Jo", Birthdate = new DateTime(2000, 10, 10) }
                );

            modelBuilder.Entity<Prescription>().HasData(
                new Prescription
                {
                    IdPrescription = 1,
                    Date = new DateTime(2020, 1, 1),
                    DueDate = new DateTime(2020, 2, 1),
                    IdPatient = 1,
                    IdDoctor = 3
                },
                new Prescription
                {
                    IdPrescription = 2,
                    Date = new DateTime(2020, 1, 11),
                    DueDate = new DateTime(2020, 3, 1),
                    IdPatient = 2,
                    IdDoctor = 1
                },
                new Prescription
                {
                    IdPrescription = 3,
                    Date = new DateTime(2021, 1, 1),
                    DueDate = new DateTime(2021, 1, 14),
                    IdPatient = 3,
                    IdDoctor = 3
                });

            modelBuilder.Entity<Medicament>().HasData(
                new Medicament { IdMedicament = 1, Name = "Smthbufen", Description = "It does not help at all", Type = "Type A" },
                new Medicament { IdMedicament = 2, Name = "Nothingderon", Description = "Make you happier", Type = "Type B" },
                new Medicament { IdMedicament = 3, Name = "Ibuproshit", Description = "Take it once before TAK", Type = "Type C" },
                new Medicament { IdMedicament = 4, Name = "Vitamin DB", Description = "For database engineers", Type = "Type A" }
                );

            modelBuilder.Entity<PrescriptionMedicament>().HasData(
                new PrescriptionMedicament { IdMedicament = 1, IdPrescription = 1, Dose = 1, Details = "Do not mix with alchohol" },
                new PrescriptionMedicament { IdMedicament = 1, IdPrescription = 2, Dose = 2, Details = "Twice a day" },
                new PrescriptionMedicament { IdMedicament = 3, IdPrescription = 2, Dose = null, Details = "Before meal" },
                new PrescriptionMedicament { IdMedicament = 2, IdPrescription = 3, Dose = 1, Details = "Mix with alchohol" },
                new PrescriptionMedicament { IdMedicament = 4, IdPrescription = 3, Dose = 3, Details = "Once a day" }

                );
        }
    }
}
