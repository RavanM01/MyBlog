﻿using MyBlog.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Core.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<BlogsCategories> BlogsCategories { get; set; }
    }
}
