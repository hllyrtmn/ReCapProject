using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RuleManager : IRulesService
    {
        public void NameRule(Car car)
        {
            if (car.Description.Length < 2)
            {
                throw new Exception("Car model must be a minimum of 2 characters ");
            }
        }

        public void PriceRule(Car car)
        {
            if (car.DailyPrice <= 0)
            {
                throw new Exception("Car price must be greater than 0");
            }
        }

        public void RentACar(Rental rental)
        {

            throw new NotImplementedException();
        }

    }
}
