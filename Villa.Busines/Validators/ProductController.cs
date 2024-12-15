using FluentValidation;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
           

            RuleFor(product => product.Category)
                .NotEmpty().WithMessage("Category cannot be empty.")
                .MaximumLength(100).WithMessage("Category must not exceed 100 characters.");

            RuleFor(product => product.Price)
                .NotEmpty().WithMessage("Price cannot be empty.")
                .Matches(@"^\d+(\.\d{1,2})?$").WithMessage("Price must be a valid decimal number (e.g., 100 or 100.50).");

            RuleFor(product => product.Title)
                .NotEmpty().WithMessage("Title cannot be empty.")
                .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");

            RuleFor(product => product.BedroomCount)
                .GreaterThanOrEqualTo(0).WithMessage("Bedroom count must be a non-negative number.");

            RuleFor(product => product.BathroomCount)
                .GreaterThanOrEqualTo(0).WithMessage("Bathroom count must be a non-negative number.");

            RuleFor(product => product.Area)
                .GreaterThan(0).WithMessage("Area must be a positive number.");

            RuleFor(product => product.Floor)
                .GreaterThanOrEqualTo(0).WithMessage("Floor number must be zero or greater.");

            RuleFor(product => product.ParkingCount)
                .Matches(@"^\d+$").WithMessage("Parking count must be a valid integer.");
        }
    }
}
