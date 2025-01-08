using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyBlog.Business.DTOs.User
{
    public record RegisterDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
    public class RegisterDtoValidator : AbstractValidator<RegisterDto> {
        public RegisterDtoValidator() {
            RuleFor(u => u.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50);
            RuleFor(u => u.UserName)
                .NotEmpty()
                .NotNull()
                 .MinimumLength(3)
                .MaximumLength(50);
            RuleFor(u => u.Email)
                .NotEmpty()
                .NotNull();
            RuleFor(u => u.Password)
                .NotEmpty()
                .NotNull()
                .MinimumLength(4);
            RuleFor(u => u)
                .Must(u => u.Password == u.ConfirmPassword);

        }
    }

}
