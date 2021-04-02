using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constant.Message;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);

        }

        public IResult Add(Rental business)
        {
            var rentedCars = _rentalDal.GetAll(r => r.CarId == business.CarId);
            foreach (var rentedCar in rentedCars)
            {
                if (rentedCar.ReturnDate == null)
                {
                    return new ErrorResult(Messages.InvalidRental);
                }
            }
            business.RentDate = DateTime.Now;

            _rentalDal.Add(business);
            return new SuccessResult(Messages.RentalAdded);
            
        }

        public IResult Delete(Rental business)
        {
            _rentalDal.Delete(business);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IResult Update(Rental business)
        {
            _rentalDal.Update(business);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetail(),Messages.RentalDetailListed);
        }
    }
}
