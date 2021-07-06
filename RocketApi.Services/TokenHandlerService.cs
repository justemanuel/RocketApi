﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RocketApi.Abstractions;

namespace RocketApi.Services
{
    public interface ITokenHandlerService
    {
        string GenerateJwtToken(ITokenParameters pars);
    }

    public class TokenHandlerService : ITokenHandlerService
    {
        private readonly JwtConfig _jwtConfig;

        public TokenHandlerService(IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        public string GenerateJwtToken(ITokenParameters pars)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", pars.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, pars.UserName),
                    new Claim(JwtRegisteredClaimNames.Email, pars.UserName)
                }),

                Expires = DateTime.UtcNow.AddSeconds(10),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}