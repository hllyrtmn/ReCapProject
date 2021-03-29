using System.Data;
using Business.Constraint.Message;
using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage(Messages.UserFirstNameNotEmpty);
            RuleFor(c => c.FirstName).MinimumLength(3).WithMessage(Messages.UserFirstNameMinimumLength);

            RuleFor(u => u.LastName).NotEmpty().WithMessage(Messages.UserLastNameNotEmpty);
            RuleFor(c => c.LastName).MinimumLength(3).WithMessage(Messages.UserLastNameMinimumLength);

            RuleFor(u => u.Email).NotEmpty().WithMessage(Messages.UserEmailNotEmpty);
            RuleFor(c => c.Email).MinimumLength(3).WithMessage(Messages.UserMinimumLength);
            RuleFor(c => c.Email).EmailAddress().WithMessage(Messages.UserEmailEmailAddress);


            //RuleFor(c => c.Password).MinimumLength(8).WithMessage(Messages.UserPasswordMinimumLength);
            //RuleFor(u => u.Password).NotEmpty().WithMessage(Messages.UserPasswordNotEmpty);
        }

    }
}