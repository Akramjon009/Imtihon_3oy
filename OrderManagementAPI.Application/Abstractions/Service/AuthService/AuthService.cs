﻿using FutureProjects.Domain.Entities.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OrderManagementAPI.Application.Abstractions.IService;
using OrderManagementAPI.Domen.Entites.Models;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace OrderManagementAPI.Application.Abstractions.Service.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _conf;
        private readonly IUserService _userService;

        public AuthService(IConfiguration conf, IUserService userService)
        {
            _conf = conf;
            _userService = userService;
        }

        public async Task<ResponseLogin> GenerateToken(RequestLogin user)
        {
            if (user == null)
            {
                return new ResponseLogin()
                {
                    Token = "User Not Found"
                };
            }
            var FindUser = await UserExist(user);
            if (FindUser != null)
            {
                var result = await _userService.InforToken(user.Login);
                var permission = new List<int>();

                if (FindUser.Role.ToString() == "Admin")
                {
                    permission = new List<int> { 2,3,10,22,11,23,24,25,26,27,28,29,30,31 };
                }
                else if (FindUser.Role.ToString() == "User")
                {
                    permission = new List<int> { 24,22,25, 26, 27, 28, 29, 30, 31,32,33};
                }
                else if (FindUser.Role.ToString() == "OrderManagement")
                {
                    permission = new List<int> { 1,2,3,22,5,6,7,8,9,10,24,25,26,27,28,29,30,31,33,34};
                }
                var jsonContent = JsonSerializer.Serialize(permission);

                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Role, result.Role.ToString()),
                    new Claim("Login", user.Login),
                    new Claim("UserID", result.Id.ToString()),
                    new Claim("CreatedDate", DateTime.UtcNow.ToString()),
                    new Claim("Permissions", jsonContent)
                };

                return await GenerateToken(claims);
            }

            return new ResponseLogin()
            {
                Token = "Un Authorize"
            };
        }

        public async Task<ResponseLogin> GenerateToken(IEnumerable<Claim> additionalClaims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_conf["JWT:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var exDate = Convert.ToInt32(_conf["JWT:ExpireDate"] ?? "10");

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64)
            };

            if (additionalClaims?.Any() == true)
                claims.AddRange(additionalClaims);


            var token = new JwtSecurityToken(
                issuer: _conf["JWT:ValidIssuer"],
                audience: _conf["JWT:ValidAudience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(exDate),
                signingCredentials: credentials);

            return new ResponseLogin()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };


        }


        public async Task<UserModel> UserExist(RequestLogin user)
        {

            var result = await _userService.InforToken(user.Login);

            if (user.Login == result.Login && user.Password == result.Password)
            {
                return result;
            }

            return result;
        }
    }
}
