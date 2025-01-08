using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Helpers.Exceptions.Category
{
    public class CategoryNullException:Exception
    {
        public CategoryNullException() : base("Model Yoxduki") { }
        public CategoryNullException(string? message) : base(message)
        {
        }
    }
}
