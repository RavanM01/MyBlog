using MyBlog.Business.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task Register(RegisterDto Dto);
    }
}
