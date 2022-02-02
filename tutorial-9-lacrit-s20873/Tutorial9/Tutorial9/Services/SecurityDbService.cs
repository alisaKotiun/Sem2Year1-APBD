using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tutorial9.DTOs.Request;
using Tutorial9.DTOs.Response;
using Tutorial9.Models;

namespace Tutorial9.Services
{

    public interface ISecurityDbService
    {
        public Task<IActionResult> RegisterUser(RegisterLoginRequest model);
        public Task<IActionResult> LoginUser(RegisterLoginRequest model);
        public Task<IActionResult> Refresh(string token, RefreshTokenRequest refreshToken);
    }

    public class SecurityDbService : ISecurityDbService
    {
        private IMainDbContext _context;
        private IConfiguration _configuration;

        public SecurityDbService(IMainDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<IActionResult> Refresh(string token, RefreshTokenRequest refreshToken)
        {
            AppUser user = await _context.AppUsers
                .Where(u => u.RefreshToken == refreshToken.RefreshToken)
                .FirstOrDefaultAsync();
            if (user == null)
            {
                throw new SecurityTokenException("Invalid refresh token");
            }

            if (user.RefreshTokenExp < DateTime.Now)
            {
                throw new SecurityTokenException("Refresh token expired");
            }

            var login = SecurityHelpers.GetUserIdFromAccessToken(token.Replace("Bearer ", ""), _configuration["SecretKey"]);

            Claim[] userclaim = new[] {
                    new Claim(ClaimTypes.Name, "s20873"),
                    new Claim(ClaimTypes.Role, "user"),
                    new Claim(ClaimTypes.Role, "admin")
                };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtToken = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                claims: userclaim,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: creds
            );

            user.RefreshToken = SecurityHelpers.GenerateRefreshToken();
            user.RefreshTokenExp = DateTime.Now.AddDays(1);
            await _context.SaveChangesAsync();

            return new OkObjectResult(new TokenResponseDto
            {
                accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                refreshToken = user.RefreshToken
            });
        }

        public async Task<IActionResult> LoginUser(RegisterLoginRequest model)
        {
            AppUser user = await _context.AppUsers
                .Where(u => u.Login == model.Login)
                .FirstOrDefaultAsync();

            if(user == null)
            {
                throw new UnauthorizedAccessException("User is not found");
            }

            string passwordHashFromDb = user.Password;
            string curHashedPassword = SecurityHelpers.GetHashedPasswordWithSalt(model.Password, user.Salt);

            if (passwordHashFromDb != curHashedPassword)
            {
                throw new UnauthorizedAccessException("User is unauthorized");
            }


            Claim[] userclaim = new[] {
                    new Claim(ClaimTypes.Name, "s20873"),
                    new Claim(ClaimTypes.Role, "user"),
                    new Claim(ClaimTypes.Role, "admin")
                };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                claims: userclaim,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: creds
            );

            user.RefreshToken = SecurityHelpers.GenerateRefreshToken();
            user.RefreshTokenExp = DateTime.Now.AddDays(1);
            await _context.SaveChangesAsync();

            return new OkObjectResult(new TokenResponseDto
            {
                accessToken = new JwtSecurityTokenHandler().WriteToken(token),
                refreshToken = user.RefreshToken
            });
        }

        public async Task<IActionResult> RegisterUser(RegisterLoginRequest model)
        {
            var hashedPasswordAndSalt = SecurityHelpers.GetHashedPasswordAndSalt(model.Password);

            var user = new AppUser()
            {
                Login = model.Login,
                Password = hashedPasswordAndSalt.Item1,
                Salt = hashedPasswordAndSalt.Item2,
                RefreshToken = SecurityHelpers.GenerateRefreshToken(),
                RefreshTokenExp = DateTime.Now.AddDays(1)
            };

            await _context.AppUsers.AddAsync(user);
            await _context.SaveChangesAsync();

            return new OkObjectResult($"User {model.Login} was added");
        }
    }
}
