using FluentValidation;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class CounterValidator : AbstractValidator<Counter>
    {
        public CounterValidator()
        {
            RuleFor(counter => counter.Title)
                .NotEmpty().WithMessage("Title cannot be empty.")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

            RuleFor(counter => counter.Count)
                .NotEmpty().WithMessage("Count cannot be empty.")
                .Must(IsNumeric).WithMessage("Count must be a numeric value.")
                .MaximumLength(10).WithMessage("Count must not exceed 10 characters.");
        }

        private bool IsNumeric(string value)
        {
            return int.TryParse(value, out _) || long.TryParse(value, out _);
        }
    }
}
