using Business.Constant.Message;
using Entities.Concrete;
using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b => b.BrandName).NotEmpty().WithMessage(Messages.BrandNameNotEmpty);
            RuleFor(b => b.BrandName).MinimumLength(2).WithMessage(Messages.BrandNameMinimumLength);
        }  
    }
}