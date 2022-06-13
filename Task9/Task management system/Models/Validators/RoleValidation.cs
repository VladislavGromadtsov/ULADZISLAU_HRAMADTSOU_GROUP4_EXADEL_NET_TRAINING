using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_management_system.Models.Validators
{
    public class RoleValidation : AbstractValidator<Role>
    {
        public RoleValidation()
        {
            RuleFor(x => x.Name).Length(1,50).Must(u => !u.Any(y => Char.IsWhiteSpace(y))).NotNull();
        }
    }
}
