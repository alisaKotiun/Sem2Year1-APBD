using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Services;

namespace Test.Controllers
{
    [Route("api/")]
    [ApiController]
    public class FirefightersController : ControllerBase
    {
        private IDbService _dbService;
        public FirefightersController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("actions/{idFighter}")]
        public async Task<IActionResult> GetDoctor(int idFighter)
        {
            return await _dbService.GetActions(idFighter);
        }

        [HttpPost("truck/{idFireTruck}/action/{idAction}")]
        public async Task<IActionResult> CreateDoctor(int idFireTruck, int idAction)
        {
            return await _dbService.AssignFireTruck(idFireTruck, idAction);
        }
    }
}
