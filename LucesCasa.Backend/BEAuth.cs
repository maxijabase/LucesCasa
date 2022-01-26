using LucesCasa.Common;
using LucesCasa.Models.DTO;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LucesCasa.Backend
{
    public class BEAuth
    {
        public object? Authorize(LoginDTO login)
        {
            if (login.User == "johndoe" && login.Password == "johndoe2410")
            {
                var secretKey = new SymmetricSecurityKey(ServiceConfiguration.Key);
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddHours(5),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return new { Token = tokenString };
            }
            return null;
        }
    }
}
