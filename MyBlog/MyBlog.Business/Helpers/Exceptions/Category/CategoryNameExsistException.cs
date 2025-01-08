using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Helpers.Exceptions.Category
{
    public class CategoryNameExsistException:Exception
    {
        public CategoryNameExsistException() : base("SAme NAme Issue ")
        {
        }

        public CategoryNameExsistException(string? message) : base(message)
        {
        }
    }
}
