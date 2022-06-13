using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_management_system.Models.Validators
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(u => u.FullName).NotEmpty().Must(u => !u.Any(y => Char.IsWhiteSpace(y))).Length(1, 50).NotNull();
            RuleFor(u => u.Email).NotEmpty().EmailAddress().NotNull();
            RuleFor(u => u.Password).Length(6, 20).Must(u => !u.Any(y => Char.IsWhiteSpace(y))).NotNull();
            RuleFor(u => u.Role).SetValidator(new RoleValidation());
        }
    }
}
