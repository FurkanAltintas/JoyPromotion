using FluentValidation;
using JoyPromotion.Dtos.Dtos;

namespace JoyPromotion.Business.ValidationRules.FluentValidation.DtoValidators
{
    public class ContactAddDtoValidator : AbstractValidator<ContactAddDto>
    {
        public ContactAddDtoValidator()
        {
            RuleFor(c => c.FullName).NotEmpty();
            RuleFor(c => c.Email).NotEmpty();
            RuleFor(c => c.Subject).NotEmpty();
            RuleFor(c => c.Message).NotEmpty();
            RuleFor(c => c.CaptchaCode).Length(4).NotEmpty();
        }
    }
}
