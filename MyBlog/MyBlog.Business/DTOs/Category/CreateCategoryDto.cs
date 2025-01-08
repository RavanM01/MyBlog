using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.DTOs.Category
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }

    }
    public class CreatCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreatCategoryDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Error var")
                .NotNull()
                .WithMessage("Error var");

        }
    }
}
