using FluentValidation;
using MVCFirmaCagri.Models.Entitiy;

namespace MVCFirmaCagri.Validation
{
    public class CompanyValidate : AbstractValidator<Company>
    {
        public CompanyValidate()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("LÜTFEN ŞİRKET ADINI BOŞ GEÇMEYİNİZ !!");
            RuleFor(x => x.CompanyTel).NotEmpty().WithMessage("LÜTFEN ŞİRKET TELEFON BOŞ GEÇMEYİNİZ !!");
            RuleFor(x => x.CompanyMail).NotEmpty().WithMessage("LÜTFEN ŞİRKET MAİL BOŞ GEÇMEYİNİZ !!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("LÜTFEN ŞİRKET ŞİFRENİZİ BOŞ GEÇMEYİNİZ !!");
            RuleFor(x => x.CompanyName).MaximumLength(100).WithMessage("LÜTFEN ŞİRKET ADINI 100 KARAKTERDEN FAZLA GİREMEZSİNİZ !!");
            RuleFor(x => x.CompanyTel).MaximumLength(11).WithMessage("LÜTFEN ŞİRKET TEL NO 11 KARAKTERDEN FAZLA GİREMEZSİNİZ !!");
            RuleFor(x => x.CompanyMail).MaximumLength(70).WithMessage("LÜTFEN ŞİRKET MAİL 70 KARAKTERDEN FAZLA GİREMEZSİNİZ !!");
            RuleFor(x => x.CompanyName).MaximumLength(100).WithMessage("LÜTFEN ŞİRKET ADINI 350 KARAKTERDEN FAZLA GİREMEZSİNİZ !!");
            RuleFor(x => x.Password).MaximumLength(25).WithMessage("LÜTFEN ŞİRKET ŞİFRE 25 KARAKTERDEN FAZLA GİREMEZSİNİZ !!");
        }
    }
}