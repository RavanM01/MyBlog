using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.DTOs.User
{
    public record LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(u => u.Username)
                .NotEmpty()
                .NotNull()
                 .MinimumLength(3)
                .MaximumLength(50);

            RuleFor(u => u.Password)
                .NotEmpty()
                .NotNull()
                .MinimumLength(4);


        }
    }
}
