using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(c => c.ColorName).NotEmpty().WithMessage("Color name is can not empty");
            RuleFor(c => c.ColorName).MinimumLength(2).WithMessage("Color name must be greater than two characters ");
        }
        
    }
}