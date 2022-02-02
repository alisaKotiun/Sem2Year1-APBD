using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial9.DTOs.Request;
using Tutorial9.Services;

namespace Tutorial9.Controllers
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

        [Authorize]
        [HttpGet("doctors/{idDoctor}")]
        public async Task<IActionResult> GetDoctor(int idDoctor)
        {
            return await _dbService.GetDoctor(idDoctor);
        }

        [Authorize]
        [HttpPost("doctors/add")]
        public async Task<IActionResult> CreateDoctor(CreateOrModifyDoctorDto dto)
        {
            return await _dbService.CreateDoctor(dto);
        }

        [Authorize]
        [HttpPut("doctors/{idDoctor}")]
        public async Task<IActionResult> ModifyDoctor(int idDoctor, CreateOrModifyDoctorDto dto)
        {
            return await _dbService.ModifyDoctor(idDoctor, dto);
        }

        [Authorize]
        [HttpDelete("doctors/{idDoctor}")]
        public async Task<IActionResult> DeleteDoctor(int idDoctor)
        {
            return await _dbService.DeleteDoctor(idDoctor);
        }

        [Authorize]
        [HttpPost("prescriptions")]
        public async Task<IActionResult> GetPrescription(PrescriptionRequestDto dto)
        {
            return await _dbService.GetPrescription(dto);
        }
    }
}
