using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial7.DTOs.Request;
using Tutorial7.Models;
using Tutorial7.Services;

namespace Tutorial7.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private IDbService _dbService;

        public ClientsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("trips")]
        public async Task<IActionResult> GetTrips()
        {
            return Ok(await _dbService.GetTrips());
        }

        [HttpDelete("clients/{idClient}")]
        public async Task<IActionResult> DeleteTrip(int idClient)
        {
            return await _dbService.DeleteClient(idClient);
        }

        [HttpPost("trips/{idTrip}/clients")]
        public async Task<IActionResult> AssignClientToTrip(int idTrip, AssignClientToTripDto dto)
        {
            return await _dbService.AssignClientToTrip(idTrip, dto);
        }
    }
}
