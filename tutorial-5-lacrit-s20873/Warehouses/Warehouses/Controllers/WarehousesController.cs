using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouses.Models;
using Warehouses.Services;

namespace Warehouses.Controllers
{
    [Route("api/warehouses")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private IDatabaseService _databaseService;

        public WarehousesController(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecord(ProductWarehouse productWarehouse)
        {
            return await _databaseService.CreateRecord(productWarehouse);
        }
    }
}
