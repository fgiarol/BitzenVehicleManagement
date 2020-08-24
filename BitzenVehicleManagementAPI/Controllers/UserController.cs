using BitzenVehicleManagementAPI.DTOs;
using BitzenVehicleManagementAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BitzenVehicleManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        
        [HttpPost("SignUp")]
        public async Task<ActionResult<UserTokenDto>> SignUp([FromBody] UserInfoDto dto)
        {
            var user = new User { Email = dto.Email, UserName = dto.UserName };
            var result = await _userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
                return await BuildToken(dto);

            else
                return BadRequest("Invalid User/Password");
        }

        [HttpPost("LogIn")]
        public async Task<ActionResult<UserTokenDto>> LogIn([FromBody] UserInfoDto dto)
        {
            var result = await _signInManager.PasswordSignInAsync(dto.UserName, dto.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
                return await BuildToken(dto);

            else
            {
                ModelState.AddModelError(string.Empty, "invalid Login");
                return BadRequest(ModelState);
            }
        }

        private async Task<UserTokenDto> BuildToken(UserInfoDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["jwt:key"]);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {                
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            var response = new UserTokenDto
            {
                Expiration = DateTime.UtcNow.AddHours(1),
                Token = encodedToken
            };

            return response;
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
