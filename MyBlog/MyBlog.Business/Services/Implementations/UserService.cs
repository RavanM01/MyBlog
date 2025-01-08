using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MyBlog.Business.DTOs.User;
using MyBlog.Business.Helpers.Exceptions.UserExceptions;
using MyBlog.Business.Services.Interfaces;
using MyBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> userManager;
        readonly IMapper mapper;

        public UserService(UserManager<AppUser> userManager )
        {
            this.userManager = userManager;
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
    }
}
