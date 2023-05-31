using FluentValidation;

namespace EventMX.Application.EventItemsService.Commands;
public class UpdateEventRegistrationItemsCommandValidator : AbstractValidator<UpdateEventRegistrationItemsCommand>
{
    public UpdateEventRegistrationItemsCommandValidator()
    {
        RuleFor(v => v.Min)
            .GreaterThanOrEqualTo(1)
            .NotEmpty();

        RuleFor(v => v.Max)
           .GreaterThanOrEqualTo(1)
           .NotEmpty();

        RuleFor(v => v.Price)
            .GreaterThanOrEqualTo(1)
          .NotEmpty();
    }
}
