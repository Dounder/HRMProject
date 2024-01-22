using FluentValidation;

namespace HRM.Application.UseCases.Trackings.Commands;

public class UpdateTrackCommandValidator : AbstractValidator<UpdateTrackCommand>
{
    public UpdateTrackCommandValidator()
    {
        // Rule for TimeOut (e.g., must be after TimeIn)
        RuleFor(x => x.TimeOut).NotEmpty();

        // Rules for LunchIn and LunchOut (e.g., within TimeIn and TimeOut)
        RuleFor(x => x.LunchIn).LessThan(x => x.TimeOut).WithMessage("LunchIn must be before TimeOut.")
            .GreaterThan(x => x.LunchOut).WithMessage("LunchIn must be after LunchOut.");

        RuleFor(x => x.LunchOut).LessThan(x => x.LunchIn).WithMessage("LunchOut must be after LunchIn.")
            .LessThan(x => x.TimeOut).WithMessage("LunchOut must be before TimeOut.");
    }
}