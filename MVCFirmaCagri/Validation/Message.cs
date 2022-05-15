using FluentValidation;

namespace MVCFirmaCagri.Validation
{
    public class Message : AbstractValidator<Models.Entitiy.Message>
    {
        public Message()
        {
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("LÜTFEN MESAJ İÇERİĞİNİ BOŞ GEÇMEYİNİZ !!");
        }
    }
}