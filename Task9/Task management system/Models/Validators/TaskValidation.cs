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

            RuleFor(c => c).NotNull().When(c => c.Creator.Role.Name == "TeamLead").Must(c => (c.Performer.Role.Name == "Senior" || c.Performer.Role.Name == "Middle") && c.Status == Statuses.NotStarted);
            RuleFor(c => c).NotNull().When(c => c.Creator.Role.Name == "Senior").Must(c => c.Performer.Role.Name == "Junior" || c.Performer.Role.Name == "Middle");
            RuleFor(c => c).NotNull().When(c => c.Creator.Role.Name == "Middle").Must(c => c.Performer.Role.Name == "Junior");
            RuleFor(c => c).NotNull().When(c => c.Creator.Role.Name == "Junior").Must(c => c.Status == Statuses.Completed);
        }
    }
}
