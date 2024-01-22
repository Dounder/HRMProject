using FluentValidation;

namespace HRM.Application.UseCases.Trackings.Commands;

public class CreateTrackingCommandValidator : AbstractValidator<CreateTrackingCommand>
{
    public CreateTrackingCommandValidator()
    {
        RuleFor(x => x.EmployeeId).NotEmpty();
        RuleFor(x => x.TimeIn).NotEmpty();
    }
}