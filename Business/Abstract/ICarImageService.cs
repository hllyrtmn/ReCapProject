using System.Collections.Generic;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService 
    {
        IDataResult<List<CarImage>> GetAll();
        IResult Add(IFormFile file, CarImage carImage);
        IResult Delete(CarImage carImage);
        IResult Update(IFormFile file, CarImage carImage);
        IDataResult<CarImage> GetById(int id);
        IDataResult<CarImage> GetCarId(int id);

        IDataResult<List<CarImage>> GetCarImage(int id);




    }
}