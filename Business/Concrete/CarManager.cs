using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constraint.Message;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IRulesService _rules;

        

        public CarManager(ICarDal carDal, IRulesService rules)
        {
            _carDal = carDal;
            _rules = rules;
        }


        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IResult Add(Car business)
        {
            _rules.NameRule(business);
            _rules.PriceRule(business);
            
            _carDal.Add(business);
            return new SuccessResult(Messages.CarAdded);

        }

        public IResult Delete(Car business)
        {
            _carDal.Delete(business);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IResult Update(Car business)
        {
            _carDal.Update(business);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id),Messages.CarById);
        }

        public IDataResult<List<Car>> GetCarsBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(c => c.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>( _carDal.GetCarDetails());
        }
    }
}
