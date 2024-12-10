using FluentValidation;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(contact => contact.MapUrl)
                .NotEmpty().WithMessage("Map URL cannot be empty.")
                .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
                .WithMessage("Map URL must be a valid URL.");

            RuleFor(contact => contact.Phone)
                .NotEmpty().WithMessage("Phone number cannot be empty.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Phone number must be in a valid international format.");

            RuleFor(contact => contact.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().WithMessage("Email must be a valid email address.");
        }
    }
}
