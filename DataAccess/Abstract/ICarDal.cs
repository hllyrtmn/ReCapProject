using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
        List<CarDetailDto> GetCarDetailsBrand(int brandId);
        List<CarDetailDto> GetCarDetailsColor(int colorId);
        CarDetailDto GetCarDetailsById(int carId);

        List<CarDetailDto> GetCarFilterByColorBrand(int colorId, int brandId);
    }
}
