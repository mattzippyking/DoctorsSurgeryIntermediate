using DoctorSurgery.Authentication.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace DoctorSurgery.Authentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {

        private IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]UserModel login)
        {
            IActionResult response = Unauthorized(); 
            
            var user = AuthenticateUser(login);

            if (user != null) 
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new {token = tokenString});
            }

            return response; 
        }

        public string GenerateJSONWebToken(UserModel userInfo) 
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(_configuration["Jwt.Issuer"],
                _configuration["Jwt.Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        private UserModel AuthenticateUser(UserModel login) 
        {
            UserModel user = null;

            if (login.UserName == "mattzipyking")
            {
                user = new UserModel { UserName = "mattzippyking", Email = "mattzippyking@aol.com" };
            }
            return user;
        }


    }
}
