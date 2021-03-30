using Business.Constant.Message;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(c => c.ColorName).NotEmpty().WithMessage(Messages.ColorNameNotEmpty);
            RuleFor(c => c.ColorName).MinimumLength(2).WithMessage(Messages.ColorNameMinimumLength);
        }
        
    }
}