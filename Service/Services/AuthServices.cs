using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Service.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Domain.Models;
using System.IdentityModel.Tokens.Jwt;

namespace Services.Serviese
{
    public class AuthServices 
    {
        private readonly SymmetricSecurityKey key;

        public AuthServices(IConfiguration config)
        {
            key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }



        public string CreateToken(User user)
        {
            var claims = new List<Claim>
        {
           new Claim(JwtRegisteredClaimNames.NameId,user.Id.ToString()),
           new Claim(JwtRegisteredClaimNames.NameId,user.Name)
       };
            var crads = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var TokenDescrption = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(50),
                SigningCredentials = crads,
            };
            var TokenHandler = new JwtSecurityTokenHandler();
            var token = TokenHandler.CreateToken(TokenDescrption);
            return TokenHandler.WriteToken(token);
        }
    }
}
