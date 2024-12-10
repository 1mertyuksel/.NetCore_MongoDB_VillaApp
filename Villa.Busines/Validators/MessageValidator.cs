using FluentValidation;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(message => message.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

            RuleFor(message => message.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().WithMessage("Email must be a valid email address.");

            RuleFor(message => message.Subject)
                .NotEmpty().WithMessage("Subject cannot be empty.")
                .MaximumLength(200).WithMessage("Subject must not exceed 200 characters.");

            RuleFor(message => message.MessageContent)
                .NotEmpty().WithMessage("Message content cannot be empty.")
                .MaximumLength(1000).WithMessage("Message content must not exceed 1000 characters.");

            RuleFor(message => message.MessageDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Message date cannot be in the future.");
        }
    }
}
