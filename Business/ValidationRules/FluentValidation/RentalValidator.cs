using System.Data;
using Business.Constraint.Message;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotEmpty().WithMessage(Messages.RentalCarIdNotEmpty);
            RuleFor(r => r.RentDate).NotEmpty().WithMessage(Messages.RentalRentDateNotEmpty);
            RuleFor(r => r.CustomerId).NotEmpty().WithMessage(Messages.RentalCustomerIdNotEmpty);
        }
    }
}