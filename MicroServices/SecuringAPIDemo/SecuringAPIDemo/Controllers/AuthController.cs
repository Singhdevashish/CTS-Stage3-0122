using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SecuringAPIDemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace SecuringAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;

        public AuthController(UserManager<ApplicationUser> userManager,
                              RoleManager<IdentityRole> roleManager,
                              IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            //IdentityUser appUser = await userManager.FindByNameAsync(model.Username);
            ApplicationUser appUser = await userManager.FindByNameAsync(model.Username);

            if (appUser == null) return BadRequest("Invalid username/password");

            bool isValid = await userManager.CheckPasswordAsync(appUser, model.Password);

            if (!isValid) return BadRequest("Invalid username/password");


            string key = configuration["JwtSettings:Key"];
            string issuer = configuration["JwtSettings:Issuer"];
            string audience = configuration["JwtSettings:Audience"];
            int durationInMinutes = int.Parse(configuration["JwtSettings:DurationInMinutes"]);

            IList<Claim> userClaims = await userManager.GetClaimsAsync(appUser);
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Sub, appUser.UserName));

            var roles = await userManager.GetRolesAsync(appUser);
            userClaims.Add(new Claim(ClaimTypes.Role, roles.First()));

            byte[] keyBytes = System.Text.Encoding.ASCII.GetBytes(key);
            SecurityKey securityKey = new SymmetricSecurityKey(keyBytes);
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: DateTime.Now.AddMinutes(durationInMinutes),
                signingCredentials: signingCredentials,
                claims: userClaims
                );
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string token = tokenHandler.WriteToken(jwtSecurityToken);
            var response = new { jwt = token, name = appUser.FullName, role= roles.First() };
            return Ok(response);
        }
    }
}
