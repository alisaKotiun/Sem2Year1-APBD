using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial9.DTOs.Request;
using Tutorial9.Models;
using Tutorial9.Services;

namespace WebApiExample.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private ISecurityDbService _dbService;

        public AccountsController(ISecurityDbService dbService)
        {
            _dbService = dbService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterLoginRequest model)
        {
            return await _dbService.RegisterUser(model);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(RegisterLoginRequest model)
        {
            return await _dbService.LoginUser(model);
        }

        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromHeader(Name = "Authorization")] string token, RefreshTokenRequest refreshToken)
        {
            return await _dbService.Refresh(token, refreshToken);
        }
    }
}
