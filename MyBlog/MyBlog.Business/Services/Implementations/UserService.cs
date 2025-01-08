using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyBlog.Business.DTOs.User;
using MyBlog.Business.Helpers.Exceptions.UserExceptions;
using MyBlog.Business.Services.Interfaces;
using MyBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> userManager;
        readonly IConfiguration configuration;
        readonly IMapper mapper;

        public UserService(UserManager<AppUser> userManager, IMapper mapper, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.configuration = configuration;
        }
        public async Task Register(RegisterDto Dto)
        {
            if (await userManager.FindByEmailAsync(Dto.Email) != null)
            {
                throw new UserRegisterException();
            }
            var appuser=mapper.Map<AppUser>(Dto);
            var result = await userManager.CreateAsync(appuser,Dto.Password);
            if (!result.Succeeded)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var err in result.Errors)
                {
                    sb.Append(err.Description + " ");
                }
                throw new UserRegisterException(sb.ToString());
            }
        }
        public async Task<string> Login(LoginDto Dto)
        {
            var user = await userManager.FindByNameAsync(Dto.Username);
            if (user == null)
            {
                throw new UserLoginException();
            }
            var result=await userManager.CheckPasswordAsync(user,Dto.Password);
            if(!result) throw new UserLoginException();

            var Claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Name,user.UserName)
            };
            
            SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecurityKey"]));
            SigningCredentials signingCredentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            
            JwtSecurityToken jwtToken = new JwtSecurityToken(
                audience: configuration["JWT:Audience"],
                issuer: configuration["JWT:Issuer"],
                claims:Claims,
                signingCredentials: signingCredentials,                
                expires:DateTime.UtcNow.AddMinutes(60)
                );
            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return token; 

        }
    }
}
