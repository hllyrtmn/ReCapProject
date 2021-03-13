using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).NotEmpty().WithMessage("Car name is can not empty");
            RuleFor(c=>c.Description).MinimumLength(2).WithMessage("Car name must be greater than two characters ");
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage("Car daily price must be greater than '0'");
        }

    }
}