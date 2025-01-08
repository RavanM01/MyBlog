using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DAL.Configurations
{
    public class BlogsCategoriesConfiguration : IEntityTypeConfiguration<BlogsCategories>
    {
        public void Configure(EntityTypeBuilder<BlogsCategories> builder)
        {
            builder.HasOne(x => x.Category)
                .WithMany(x => x.BlogsCategories)
                .HasForeignKey(x => x.CategoryId);

            builder.HasOne(x => x.Blog)
                .WithMany(x => x.BlogsCategories)
                .HasForeignKey(x => x.BlogId);

            builder.Ignore(x=>x.IsDeleted);
        }
    }
}
