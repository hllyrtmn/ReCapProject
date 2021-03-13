using System.Data;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("First name is can not empty");
            RuleFor(c => c.FirstName).MinimumLength(3).WithMessage("First name must be greater than three characters ");

            RuleFor(u => u.LastName).NotEmpty().WithMessage("Last name is can not empty");
            RuleFor(c => c.LastName).MinimumLength(3).WithMessage("Last name must be greater than three characters ");

            RuleFor(u => u.Email).NotEmpty().WithMessage("Email is can not empty");
            RuleFor(c => c.Email).MinimumLength(3).WithMessage("Email must be greater than three characters ");
            RuleFor(c => c.Email).EmailAddress().WithMessage("A valid email address is required.");


            RuleFor(c => c.Password).MinimumLength(8).WithMessage("Password must be greater than eight characters ");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Password is can not empty");
        }

    }
}