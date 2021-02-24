using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RuleManager : IRulesService
    {
        public void NameRule(Car car)
        {
            if (car.Description.Length < 2)
            {
                throw new Exception("Araba Modeli minimum 2 karakter girilmelidir.");
            }
        }

        public void PriceRule(Car car)
        {
            if (car.DailyPrice <= 0)
            {
                throw new Exception("Araç için 0 TL'den büyük bir fiyat girilmelidir.");
            }
        }
    }
}
