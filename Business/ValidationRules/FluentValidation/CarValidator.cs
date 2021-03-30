using Business.Constant.Message;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).NotEmpty().WithMessage(Messages.CarNotEmpty);
            RuleFor(c=>c.Description).MinimumLength(2).WithMessage(Messages.CarMinimumLength);
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage(Messages.CarGreaterThan);
        }

    }
}