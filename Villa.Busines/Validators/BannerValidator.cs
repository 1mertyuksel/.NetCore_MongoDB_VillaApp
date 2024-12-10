using FluentValidation;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class BannerValidator : AbstractValidator<Banner>
    {
        public BannerValidator()
        {
            RuleFor(banner => banner.City)
                .NotEmpty().WithMessage("City field cannot be empty.")
                .MaximumLength(50).WithMessage("City field must not exceed 50 characters.");

            RuleFor(banner => banner.Title)
                .NotEmpty().WithMessage("Title field cannot be empty.")
                .MaximumLength(100).WithMessage("Title field must not exceed 100 characters.");

            RuleFor(banner => banner.ImageUrl)
                .NotEmpty().WithMessage("Image URL field cannot be empty.")
                .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
                .WithMessage("Image URL must be a valid URL.");
        }
    }
}
