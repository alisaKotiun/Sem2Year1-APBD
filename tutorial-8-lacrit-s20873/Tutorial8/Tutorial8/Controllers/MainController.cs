using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial8.DTOs.Request;
using Tutorial8.Services;

namespace Tutorial8.Controllers
{
    [Route("api/")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private IDbService _dbService;

        public MainController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("doctors/{idDoctor}")]
        public async Task<IActionResult> GetDoctor(int idDoctor)
        {
            return await _dbService.GetDoctor(idDoctor);
        }

        [HttpPost("doctors/add")]
        public async Task<IActionResult> CreateDoctor(CreateOrModifyDoctorDto dto)
        {
            return await _dbService.CreateDoctor(dto);
        }

        [HttpPut("doctors/{idDoctor}")]
        public async Task<IActionResult> ModifyDoctor(int idDoctor, CreateOrModifyDoctorDto dto)
        {
            return await _dbService.ModifyDoctor(idDoctor, dto);
        }

        [HttpDelete("doctors/{idDoctor}")]
        public async Task<IActionResult> DeleteDoctor(int idDoctor)
        {
            return await _dbService.DeleteDoctor(idDoctor);
        }

        [HttpPost("prescriptions")]
        public async Task<IActionResult> GetPrescription(PrescriptionRequestDto dto)
        {
            return await _dbService.GetPrescription(dto);
        }
    }
}
