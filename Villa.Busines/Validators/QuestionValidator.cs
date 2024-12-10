using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class QuestionValidator : AbstractValidator<Quest>
    {
        public QuestionValidator()
        {
            RuleFor(x => x.Question).NotEmpty().WithMessage("SoruBoş Bırakılamaz");
            RuleFor(x => x.Question).MinimumLength(5).WithMessage("Minimum 10 karakterlik bir soru giriniz");
            RuleFor(x => x.Question).MaximumLength(200).WithMessage("Maximum 200 karakterlik bir soru giriniz");
            RuleFor(x => x.Answer).NotEmpty().WithMessage("Cevap Boş Bırakılamaz");
            RuleFor(x => x.Answer).MinimumLength(5).WithMessage("Minimum 10 karakterlik bir cevap giriniz");
            RuleFor(x => x.Answer).MaximumLength(200).WithMessage("Maximum 200 karakterlik bir cevap giriniz");
        }
    }
}
