﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IronFit.Domain.AuthAggregate.Dtos;
using IronFit.Domain.AuthAggregate.Entities;
using IronFit.Domain.AuthAggregate.Repositories;
using IronFit.Domain.AuthAggregate.Services;
using IronFit.Domain.Properties;
using IronFit.Domain.Shared.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using BC = BCrypt.Net.BCrypt;

namespace IronFit.Application.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, 
            IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public string Login(LoginDto loginDto)
        {
            var user = _userRepository.GetByUsername(loginDto.Username);

            if (user is null) throw new CoreException(Resources.LoginInvalido);

            if (!BC.Verify(loginDto.Password, user.PasswordHash)) throw new CoreException(Resources.LoginInvalido);

            var token = GenerateToken(user);

            return token;
        }

        public string GeneratePasswordHash(string password)
        {
            var passwordHash = BC.HashPassword(password);

            return passwordHash;
        }

        private string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("Admin", user.Admin.ToString())
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Security:SecretKeyJWT"]));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = signingCredentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
