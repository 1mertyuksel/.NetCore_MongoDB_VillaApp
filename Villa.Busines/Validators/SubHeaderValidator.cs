using FluentValidation;
using MongoDB.Bson;
using Villa.Entity.Entities;

public class SubHeaderValidator : AbstractValidator<SubHeader>
{
    public SubHeaderValidator()
    {
        

        RuleFor(x => x.Adress)
            .NotEmpty().WithMessage("Adres alanı boş olamaz.")
            .MaximumLength(250).WithMessage("Adres 250 karakterden uzun olamaz.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email alanı boş olamaz.")
            .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");

        RuleFor(x => x.Facebook)
            .MaximumLength(100).WithMessage("Facebook alanı 100 karakterden uzun olamaz.");

        RuleFor(x => x.Twitter)
            .MaximumLength(100).WithMessage("Twitter alanı 100 karakterden uzun olamaz.");

        RuleFor(x => x.Linkedin)
            .MaximumLength(100).WithMessage("Linkedin alanı 100 karakterden uzun olamaz.");

        RuleFor(x => x.Instagram)
            .MaximumLength(100).WithMessage("Instagram alanı 100 karakterden uzun olamaz.");
    }
}