using System.Data;
using Business.Constant.Message;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.CompanyName).NotEmpty().WithMessage(Messages.CustomerCompanyNameNotEmpty);
            RuleFor(c => c.CompanyName).MinimumLength(3).WithMessage(Messages.CustomerCompanyNameMinimumLength);

        }
        
    }
}