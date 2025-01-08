using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.DTOs.Blog
{
    public record CreateBlogDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        
    }
}
