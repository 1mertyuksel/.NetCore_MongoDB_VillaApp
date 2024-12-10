using FluentValidation;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class DealValidator : AbstractValidator<Deal>
    {
        public DealValidator()
        {
            RuleFor(deal => deal.Type)
                .NotEmpty().WithMessage("Type cannot be empty.")
                .MaximumLength(50).WithMessage("Type must not exceed 50 characters.");

            RuleFor(deal => deal.ImageUrl)
                .NotEmpty().WithMessage("Image URL cannot be empty.")
                .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
                .WithMessage("Image URL must be a valid URL.");

            RuleFor(deal => deal.Title)
                .NotEmpty().WithMessage("Title cannot be empty.")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

            RuleFor(deal => deal.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(deal => deal.Square)
                .NotEmpty().WithMessage("Square cannot be empty.")
                .Matches(@"^\d+$").WithMessage("Square must be a numeric value.");

            RuleFor(deal => deal.Floor)
                .NotEmpty().WithMessage("Floor cannot be empty.")
                .Matches(@"^\d+$").WithMessage("Floor must be a numeric value.");

            RuleFor(deal => deal.RoomCount)
                .NotEmpty().WithMessage("Room count cannot be empty.")
                .Matches(@"^\d+$").WithMessage("Room count must be a numeric value.");

            RuleFor(deal => deal.PaymentType)
                .NotEmpty().WithMessage("Payment type cannot be empty.")
                .MaximumLength(50).WithMessage("Payment type must not exceed 50 characters.");
        }
    }
}
