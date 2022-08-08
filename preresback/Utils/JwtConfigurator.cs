using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using preresback.Domain.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace preresback.Utils
{
    public class JwtConfigurator
    {
        public static string GetToken(Usuario userInfo, IConfiguration config)
        {
            string SecretKey = config["jwt:SecretKey"];
            string Issuer = config["jwt:Issuer"];
            string Audience = config["jwt:Audience"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.NombreUsuario),
                new Claim("idUsuario", userInfo.Id.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
