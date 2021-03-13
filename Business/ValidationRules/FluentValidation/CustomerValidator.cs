using System.Data;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.CompanyName).NotEmpty().WithMessage("Company name is can not empty");
            RuleFor(c => c.CompanyName).MinimumLength(3).WithMessage("Company name must be greater than three characters ");

        }
        
    }
}