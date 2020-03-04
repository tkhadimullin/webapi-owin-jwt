using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Web.Http;
using Microsoft.IdentityModel.Tokens;
using Claim = System.Security.Claims.Claim;

namespace OWIN.WebApi.Controllers
{
    // this class is literally just a test harness to help me generate a valid token for popping into Postman.
    public class ObtainJwtController: ApiController
    {
        private string CraftJwt()
        {
            string key = "jwt_signing_secret_key"; //Secret key which will be used later during validation    
            var issuer = "http://localhost";

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var permClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("valid", "1"),
                new Claim("userid", "1"),
                new Claim("name", "test")
            };

            var token = new JwtSecurityToken(issuer,
                issuer,
                permClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string Get()
        {
            return $"Bearer {CraftJwt()}";
        }
    }
}