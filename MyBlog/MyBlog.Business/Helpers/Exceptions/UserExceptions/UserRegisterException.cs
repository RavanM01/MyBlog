using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Helpers.Exceptions.UserExceptions
{
    public class UserRegisterException:Exception
    {
        public UserRegisterException() : base("Register xetasii")
        {
        }

        public UserRegisterException(string? message) : base(message)
        {
        }
    }
}
