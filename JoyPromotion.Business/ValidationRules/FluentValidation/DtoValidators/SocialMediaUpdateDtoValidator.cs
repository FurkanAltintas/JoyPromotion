using FluentValidation;
using JoyPromotion.Dtos.Dtos;

namespace JoyPromotion.Business.ValidationRules.FluentValidation.DtoValidators
{
    public class SocialMediaUpdateDtoValidator : AbstractValidator<SocialMediaUpdateDto>
    {
        public SocialMediaUpdateDtoValidator()
        {
            RuleFor(s => s.Id).InclusiveBetween(1, int.MaxValue);
            RuleFor(s => s.Name).NotEmpty();
            RuleFor(s => s.Icon).NotEmpty();
        }
    }
}
