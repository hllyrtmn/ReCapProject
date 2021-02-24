using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        ICarDal _carDal;
        IRulesService _rules;

        public CarManager(ICarDal carDal, IRulesService rules)
        {
            _carDal = carDal;
            _rules = rules;
        }


        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public void Add(Car business)
        {
           _rules.NameRule(business);
           _rules.PriceRule(business);
           _carDal.Add(business);

        }

        public void Delete(Car business)
        {
            _carDal.Delete(business);
        }

        public void Update(Car business)
        {
           _carDal.Delete(business);
        }

        public Car GetById(int id)
        {
            throw null;
        }

        public List<Car> GetCarsBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }
    }
}
