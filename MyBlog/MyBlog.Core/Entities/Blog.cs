using MyBlog.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Core.Entities
{
    public class Blog:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ViewerCount { get; set; }
        public string AuthorId { get; set; } 
        public AppUser Author { get; set; }
        public ICollection<BlogsCategories> BlogsCategories { get; set; }
    }
}
