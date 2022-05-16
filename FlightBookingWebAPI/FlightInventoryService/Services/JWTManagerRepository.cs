﻿using FlightInventoryService.Models;
using FlightInventoryService.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FlightInventoryService.Services
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        FlightBookingContext _flightBookingContext;
        private readonly IConfiguration configuartion;

        public JWTManagerRepository(IConfiguration iconfiguration, FlightBookingContext flightBookingContext)
        {
            configuartion = iconfiguration;
            _flightBookingContext = flightBookingContext;
        }
        public Tokens Authenticate(User users)
        {
            var userList = _flightBookingContext.TblUsers.ToList();
            if (!userList.Any(x => x.UserName == users.Name && x.Password == users.Password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(configuartion["JWT:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,users.Name)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };

        }
    }
}