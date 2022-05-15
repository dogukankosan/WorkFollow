using FluentValidation;
using MVCFirmaCagri.Models.Entitiy;

namespace MVCFirmaCagri.Validation
{
    public class LoginValidate : AbstractValidator<Company>
    {
        public LoginValidate()
        {
            RuleFor(x => x.CompanyMail).NotEmpty().WithMessage("LÜTFEN KULLANICI ADINIZI BOŞ GEÇMEYİNİZ !!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("LÜTFEN ŞİFRENİZİ BOŞ GEÇMEYİNİZ !!");
            RuleFor(x => x.CompanyMail).MaximumLength(70)
                .WithMessage("LÜTFEN KULLANICI ADINI 70 KARAKTERDEN FAZLA GİRMEYİNİZ !!");
            RuleFor(x => x.Password).MaximumLength(25)
                .WithMessage("LÜTFEN ŞİFRENİZİ 25 KARAKTERDEN FAZLA GİRMEYİNİZ !!");
        }
    }
}