using FluentValidation;

namespace EventMX.Registration.Application.EventItems.Commands;
public class CreateEventRegistrationItemsCommandValidator : AbstractValidator<CreateEventRegistrationItemsCommand>
{
    public CreateEventRegistrationItemsCommandValidator()
    {
        RuleFor(v => v.Min)
           .GreaterThanOrEqualTo(1)
           .NotEmpty();

        RuleFor(v => v.Max)
           .GreaterThanOrEqualTo(1)
           .NotEmpty();

        RuleFor(v => v.Price)
          .NotEmpty();
    }
}
