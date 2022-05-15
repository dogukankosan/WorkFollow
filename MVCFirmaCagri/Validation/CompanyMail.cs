using FluentValidation;
using MVCFirmaCagri.Models.Entitiy;

namespace MVCFirmaCagri.Validation
{
    public class CompanyMail : AbstractValidator<Company>
    {
        public CompanyMail()
        {
            RuleFor(x => x.CompanyMail).NotEmpty().WithMessage("LÜTFEN MAİL ADRESİNİZİ BOŞ GEÇMEYİNİZ !!");
            RuleFor(x => x.CompanyMail).MaximumLength(70).WithMessage("LÜTFEN 70 KARAKTERDEN FAZLA DEĞER GİRMEYİNİZ !!");
        }
    }
}