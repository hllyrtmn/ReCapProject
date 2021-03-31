using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IResult Add(Car business);
        IResult Delete(Car business);
        IResult Update(Car business);
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetCarsBrandId(int brandId);
        IDataResult<List<Car>> GetCarsColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetails();

        IResult TransactionTest(Car business);

    }
}