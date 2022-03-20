using FluentValidation;
using JoyPromotion.Dtos.Dtos;

namespace JoyPromotion.Business.ValidationRules.FluentValidation.DtoValidators
{
    public class SocialMediaAddDtoValidator : AbstractValidator<SocialMediaAddDto>
    {
        public SocialMediaAddDtoValidator()
        {
            RuleFor(s => s.Name).NotEmpty();
            RuleFor(s => s.Icon).NotEmpty();
        }
    }
}
