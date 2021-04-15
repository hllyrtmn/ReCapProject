using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constant.Message;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        [PerformanceAspect(10)]
        public IResult Add(Car business)
        {
            _carDal.Add(business);
            return new SuccessResult(Messages.CarAdded);
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car business)
        {
            _carDal.Delete(business);
            return new SuccessResult(Messages.CarDeleted);
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car business)
        {
            _carDal.Update(business);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id), Messages.CarById);
        }

        public IDataResult<List<Car>> GetCarsBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsBrand(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsBrand(brandId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsColor(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsColor(colorId));
        }

        public IDataResult<CarDetailDto> GetCarDetailsById(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetailsById(carId));
        }

        [TransactionScopeAspect]
        public IResult TransactionTest(Car business)
        {
            _carDal.Add(business);
            if (business.DailyPrice<50)
            {
                throw new Exception("");
            }
            _carDal.Add(business);
            return null;
        }

        public IDataResult<List<CarDetailDto>> GetCarFilterByColorBrand(int colorId, int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>( _carDal.GetCarFilterByColorBrand(colorId, brandId));

        }
    }
}
