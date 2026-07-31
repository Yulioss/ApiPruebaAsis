using ApiPruebaAsis.Application.DTOs;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using ApiPruebaAsis.Application.Interfaces;

namespace ApiPruebaAsis.Infrastructure.Security
{
    public class JwtTokenGenerator: IJwtTokenGenerator
    {
        private readonly IConfiguration _configuration;

        public JwtTokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public LoginResponseDto GenerateToken(string username)
        {
            var jwt = _configuration.GetSection("Jwt");

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwt["Key"]!));

            var credentials =
                new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration =
                DateTime.UtcNow.AddMinutes(
                    Convert.ToDouble(jwt["ExpirationMinutes"]));

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username),
            new Claim("Nombre 2", "Valor 2")
            };

            var token = new JwtSecurityToken(

                issuer: jwt["Issuer"],

                audience: jwt["Audience"],

                claims: claims,

                expires: expiration,

                signingCredentials: credentials
            );

            return new LoginResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
