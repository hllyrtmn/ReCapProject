using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constant.Message;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
         ICarImageDal _carImageDal;

         public CarImageManager(ICarImageDal carImageDal)
         {
             _carImageDal = carImageDal;
         }

         public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(),Messages.CarImageListed);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.CarImageId == id));
        }


        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<CarImage> GetCarId(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.CarId == id));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<List<CarImage>> GetCarImage(int id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c=>c.CarId == id));
        }


        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {

            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }


        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarImageId));
            if (result != null)
            {   
                return result;
            }

            carImage.ImagePath = FileHelper.Update(carImage.ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }




        private IResult CheckImageLimitExceeded(int carId)
        {
            var carImageCount = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (carImageCount >= 5)
            {
                return new ErrorResult(Messages.CarImageCount);
            }

            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> CheckIfCarImageNull(int id)
        {
            try
            {
                string path = @"\uploads\default.jpg";

                var result = _carImageDal.GetAll(c => c.CarId == id).Any();

                if (!result)
                {
                    List<CarImage> carImage = new List<CarImage>();

                    carImage.Add(new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now });

                    return new SuccessDataResult<List<CarImage>>(carImage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id));
        }

       


    }





}
