using FluentValidation;

namespace HRM.Application.UseCases.Employees.Commands;

public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(x => x.Name).MaximumLength(50);
        RuleFor(x => x.Email).MaximumLength(50).EmailAddress();
        RuleFor(x => x.Phone).MaximumLength(30);
        RuleFor(x => x.Salary).GreaterThan(0);
        RuleFor(x => x.ExtraHourRate).GreaterThan(0);
        RuleFor(x => x.DepartmentId).GreaterThan(0);
        RuleFor(x => x.PositionId).GreaterThan(0);
        RuleFor(x => x.DateHired).LessThan(DateTime.UtcNow);
    }
}