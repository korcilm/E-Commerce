using API.Core.DbModels.Identity;
using API.Infrastructure.StringInfos.ECommerceWithAngular.Infrastructure.StringInfos;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Infrastructure.JWTUtility
{
    public class JwtManager : IJwtService
    {
        private readonly IOptions<JWTInfo> _optionsJwt;
        public JwtManager(IOptions<JWTInfo> optionsJwt)
        {
            _optionsJwt = optionsJwt;
        }
        public JwtToken GenerateJWTToken(AppUser appUser)
        {

            var claim = new List<Claim>
            {

                new Claim (JwtRegisteredClaimNames.Email,appUser.Email),
                new Claim (JwtRegisteredClaimNames.GivenName,appUser.DisplayName)
            };

            var jwtInfo = _optionsJwt.Value;
            var bytes = Encoding.UTF8.GetBytes(jwtInfo.SecurityKey); //startup la aynı olmalı 
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer: jwtInfo.Issuer, audience: jwtInfo.Audience,
                notBefore: DateTime.Now, expires: DateTime.Now.AddHours(jwtInfo.TokenExpiration), signingCredentials: credentials, claims: claim);

            JwtToken jwtToken = new JwtToken();
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            jwtToken.Token = handler.WriteToken(jwtSecurityToken);
            return jwtToken;
        }        
    }
}
