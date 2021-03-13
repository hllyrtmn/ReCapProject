using System.Data;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotEmpty().WithMessage("Car ID is can not empty");
            RuleFor(r => r.RentDate).NotEmpty().WithMessage("Rental date is can not empty");
            RuleFor(r => r.CustomerId).NotEmpty().WithMessage("Customer ID is can not empty");
        }
    }
}