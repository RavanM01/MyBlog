using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Helpers.Exceptions.UserExceptions
{
    public class UserLoginException : Exception
    {
        public UserLoginException():base("Login datalari sehvdir")
        {
        }

        public UserLoginException(string? message) : base(message)
        {
        }
    }
}
