using FluentValidation;

namespace MVCFirmaCagri.Validation
{
    public class CompanyCall : AbstractValidator<Models.Entitiy.CompanyCall>
    {
        public CompanyCall()
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage("LÜTFEN ÇAĞRI KONUYU BOŞ GEÇMEYİNİZ !!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("LÜTFEN ÇAĞRI AÇIKLAMA BOŞ GEÇMEYİNİZ !!");
            RuleFor(x => x.C_Date).NotEmpty().WithMessage("LÜTFEN ÇAĞRI TARİH BOŞ GEÇMEYİNİZ !!");
            RuleFor(x => x.CompanyID).NotEmpty()
                .WithMessage("LÜTFEN ŞİRKET ADI BOŞ GEÇMEYİNİZ TEKRAR GİRİŞ YAPINIZ !!");
            RuleFor(x => x.Subject).MaximumLength(200).WithMessage("LÜTFEN ÇAĞRI KONU 200 KARAKTERDEN FAZLA OLAMAZ !!");
        }
    }
}