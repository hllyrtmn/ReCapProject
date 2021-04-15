using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constant.Message;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental business)
        {
            var rentedCars = BusinessRules.Run(CantItBeRented(business.CarId,business.RentDate,(DateTime) business.ReturnDate));

            if (rentedCars != null)
            {
                return new ErrorResult(Messages.RentalReturnDateNull);
            }

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


        private IResult CantItBeRented(int carId, DateTime rentDate, DateTime returnDate)
        {
            var rentalResult = _rentalDal.GetAll(c => c.CarId == carId).Any();
            if (rentalResult)
            {
                var result = _rentalDal.GetAll(c=>c.CarId == carId);
                foreach (var rental in result)
                {
                    if (rental.ReturnDate == null)
                    {
                        return new ErrorResult(Messages.RentalReturnDateNull);
                    }
                    var rentRange = DateTime.Compare((DateTime)rental.ReturnDate, rentDate);
                    var returnRange = DateTime.Compare((DateTime)rental.RentDate,returnDate);

                    if (rentRange > 0 || returnRange > 0)
                    {
                        return new ErrorResult(Messages.RentalReturnDateNull);
                    }
                }
            }
            return new SuccessResult(Messages.RentalAdded);
        }
    }
}
