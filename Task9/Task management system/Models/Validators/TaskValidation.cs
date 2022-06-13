using FluentValidation;

namespace Task_management_system.Models.Validators
{
    public class TaskValidation : AbstractValidator<Task>
    {
        public TaskValidation()
        {
            RuleFor(c => c.Name).NotEmpty().Must(u => !u.Any(x => Char.IsWhiteSpace(x))).NotNull().Length(1,100).NotNull();
            RuleFor(c => c.Description).Length(0, 2000);
            RuleFor(c => c.Status).NotNull();

            RuleFor(c => c.Creator).SetValidator(new UserValidation());
            RuleFor(c => c.Performer).SetValidator(new UserValidation());
        }
    }
}
