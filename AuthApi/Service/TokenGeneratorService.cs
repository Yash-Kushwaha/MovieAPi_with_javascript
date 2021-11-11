using AuthApi.Models;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthApi.Service
{
    public class TokenGeneratorService : ITokenGeneratorService
    {
        public string GenerateJWTToken(string userName, User user)
        {
            var claims = new[]
            {
                new Claim("UserName",user.UserName),
                new Claim("Gmail",user.Gmail),
                new Claim("Password", user.Password)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this_is_my_secret_key"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "UserWebApi",
                audience: "MovieWebApi",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            var response = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
            };

            return JsonConvert.SerializeObject(response);

        }
    }
}
