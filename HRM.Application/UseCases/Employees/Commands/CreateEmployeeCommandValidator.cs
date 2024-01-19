using FluentValidation;
using HRM.Domain.Entities.Employees;

namespace HRM.Application.UseCases.Employees.Commands;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
        RuleFor(x => x.Phone).NotEmpty().MaximumLength(30);
        RuleFor(x => x.Salary).NotEmpty().GreaterThan(0);
        RuleFor(x => x.ExtraHourRate).GreaterThan(0);
        RuleFor(x => x.DepartmentId).NotEmpty().GreaterThan(0);
        RuleFor(x => x.PositionId).NotEmpty().GreaterThan(0);
        RuleFor(x => x.DateHired).LessThan(DateTime.UtcNow);
    }
}