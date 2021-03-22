using Business.Constraint.Message;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(c => c.CarId).NotNull().WithMessage(Messages.CarIdIdNotEmpty);
            RuleFor(c => c.ImagePath).NotNull().WithMessage(Messages.CarImagePathNotEmpty);
            RuleFor(c => c.Date).NotNull().WithMessage(Messages.CarDateNotEmpty);
        }

    }
}