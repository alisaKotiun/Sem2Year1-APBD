using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial8.DTOs.Request;
using Tutorial8.DTOs.Response;
using Tutorial8.Models;

namespace Tutorial8.Services
{
    public interface IDbService
    {
        public Task<IActionResult> GetDoctor(int id);
        public Task<IActionResult> CreateDoctor(CreateOrModifyDoctorDto dto);
        public Task<IActionResult> ModifyDoctor(int id, CreateOrModifyDoctorDto dto);
        public Task<IActionResult> DeleteDoctor(int id);
        public Task<IActionResult> GetPrescription(PrescriptionRequestDto dto);
    }
    public class ClinicDbService : IDbService
    {
        private IMainDbContext _context;

        public ClinicDbService(IMainDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> GetDoctor(int id)
        {
            if (!await CheckDoctor(id)) return new BadRequestObjectResult($"Doctor {id} does not exist");

            var doctor = await _context.Doctors
                .Include(d => d.Prescriptions)
                .Where(d => d.IdDoctor == id)
                .Select(d => new GetDoctorDto
                {
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Email = d.Email,
                    Prescriptions = d.Prescriptions
                                    .Select(p => new GetPrescriptionDto
                                    {
                                        IdPrescription = p.IdPrescription,
                                        Date = p.Date,
                                        DueDate = p.DueDate
                                    })
                })
                .SingleOrDefaultAsync();
            return new OkObjectResult(doctor);
        }

        public async Task<IActionResult> CreateDoctor(CreateOrModifyDoctorDto dto)
        {
            var doctor = new Doctor
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email
            };

            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return new OkObjectResult($"Doctor {doctor.IdDoctor} was added to system");
        }

        public async Task<IActionResult> ModifyDoctor(int id, CreateOrModifyDoctorDto dto)
        {
            if (!await CheckDoctor(id)) return new BadRequestObjectResult($"Doctor {id} does not exist");

            var doctor = new Doctor
            {
                IdDoctor = id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email
            };

            _context.Doctors.Attach(doctor);
            _context.Entry(doctor).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return new OkObjectResult(doctor);
        }
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            if (!await CheckDoctor(id)) return new BadRequestObjectResult($"Doctor {id} does not exist");

            var doctor = new Doctor { IdDoctor = id };

            _context.Doctors.Attach(doctor);
            _context.Entry(doctor).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return new OkObjectResult($"Doctor {id} was deleted");
        }
        public async Task<IActionResult> GetPrescription(PrescriptionRequestDto dto)
        {
            if (!await CheckDoctor(dto.IdDoctor)) return new BadRequestObjectResult($"Doctor {dto.IdDoctor} does not exist");
            if (!await CheckPatient(dto.IdPatient)) return new BadRequestObjectResult($"Patient {dto.IdPatient} does not exist");

            var prescription = await _context.Prescriptions
                .Include(p => p.PrescriptionMedicaments)
                .Where(p => p.IdDoctor == dto.IdDoctor && p.IdPatient == dto.IdPatient) 
                .Where(p => p.PrescriptionMedicaments.Select(p => p.IdMedicament).Count() == dto.Medicaments.Count)
                .SelectMany(p => p.PrescriptionMedicaments.Select(pm => pm.IdMedicament), 
                            (p, m) => new { Prescription = p, Medicament = m})
                .Where(p => dto.Medicaments.Any(m => m == p.Medicament))
                .Select(p => new GetPrescriptionDto
                {
                    IdPrescription = p.Prescription.IdPrescription,
                    Date = p.Prescription.Date,
                    DueDate = p.Prescription.DueDate
                })
                .Distinct()
                .ToListAsync();

            return new OkObjectResult(prescription);
        }

        private async Task<bool> CheckDoctor(int id)
        {
            return await _context.Doctors
                .AnyAsync(d => d.IdDoctor == id);
        }

        private async Task<bool> CheckPatient(int id)
        {
            return await _context.Patients
                .AnyAsync(p => p.IdPatient == id);
        }
    }
}
