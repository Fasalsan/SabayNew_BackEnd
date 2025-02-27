using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SabayNew.Models;
using SabayNew.Repository.User;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.Versioning;
using System.Security.Claims;
using System.Text;

namespace SabayNew.Controllers.UserLogin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IUserRepository _userRepository;

        public UserLoginController(IConfiguration config, IUserRepository userRepository)
        {
            _config = config;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginModel login)
        {
            IActionResult response = Unauthorized();
            var user = await AuthenticateUser(login);

            if (user != null)
            {
                var tokenString =  GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }


        private string GenerateJSONWebToken(UserLoginModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<UserLoginModel?> AuthenticateUser(UserLoginModel login)
        {
            UserLoginModel user = null;
            var existUser = await _userRepository.GetByEmail(login.Email);

            if(existUser is null)
            {
                return user;
            }

            if (existUser.Email.Equals(login.Email) && login.Password == existUser.Password) 
            {
                user = new UserLoginModel { Email = login.Email, Password = login.Password};
            }
            return user;
        }

        
    }
}
