using FluentValidation;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class FeatureValidator : AbstractValidator<Feature>
    {
        public FeatureValidator()
        {
            RuleFor(feature => feature.ImageUrl)
                .NotEmpty().WithMessage("Image URL cannot be empty.")
                .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
                .WithMessage("Image URL must be a valid URL.");

            RuleFor(feature => feature.Title)
                .NotEmpty().WithMessage("Title cannot be empty.")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

            RuleFor(feature => feature.SubTitle)
                .NotEmpty().WithMessage("SubTitle cannot be empty.")
                .MaximumLength(200).WithMessage("SubTitle must not exceed 200 characters.");

            RuleFor(feature => feature.Square)
                .NotEmpty().WithMessage("Square cannot be empty.")
                .Matches(@"^\d+$").WithMessage("Square must be a numeric value.");

            RuleFor(feature => feature.Contract)
                .NotEmpty().WithMessage("Contract cannot be empty.")
                .MaximumLength(100).WithMessage("Contract must not exceed 100 characters.");

            RuleFor(feature => feature.Safety)
                .NotEmpty().WithMessage("Safety cannot be empty.")
                .MaximumLength(100).WithMessage("Safety must not exceed 100 characters.");
        }
    }
}
