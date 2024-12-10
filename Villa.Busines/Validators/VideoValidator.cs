using FluentValidation;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class VideoValidator : AbstractValidator<Video>
    {
        public VideoValidator()
        {
            RuleFor(video => video.VideoUrl)
                .NotEmpty().WithMessage("Video URL cannot be empty.")
                .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
                .WithMessage("Video URL must be a valid URL.");
        }
    }
}
