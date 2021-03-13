using Entities.Concrete;
using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b => b.BrandName).NotEmpty().WithMessage("Brand name is can not empty");
            RuleFor(b => b.BrandName).MinimumLength(2).WithMessage("Brand name must be greater than two characters ");
        }  
    }
}