using System.Data;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Text;


namespace PracticeProject
{
    public class Auth: IAuth
    {
        private readonly IConfiguration _config;
        public Auth(IConfiguration configuration) 
        {
            _config = configuration;
        }
       public string GenerateToken(string username, string password)
        {
            var claims = new[] { 
                new Claim(JwtRegisteredClaimNames.Sub, username), 
                new Claim("password", password), 
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); 
            var token = new JwtSecurityToken( issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"], 
                claims: claims, 
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["Jwt:ExpireMinutes"])),
                signingCredentials: creds ); 
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
