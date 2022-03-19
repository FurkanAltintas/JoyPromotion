using FluentValidation;
using JoyPromotion.Dtos.Dtos;

namespace JoyPromotion.Business.ValidationRules.FluentValidation.DtoValidators
{
    public class UserUpdateDtoValidator : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateDtoValidator()
        {
            RuleFor(u => u.Id).InclusiveBetween(1, int.MaxValue);
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.SurName).NotEmpty();
            RuleFor(u => u.UserName).NotEmpty();
        }
    }
}
