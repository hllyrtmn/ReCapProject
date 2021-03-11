using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRulesService
    {
        void NameRule(Car car);
        void PriceRule(Car car);
        void RentACar(Rental rental);
    }
}
