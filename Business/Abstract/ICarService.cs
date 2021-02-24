using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarService : IBusinessRepository<Car>
    {
        List<Car> GetCarsBrandId(int brandId);
        List<Car> GetCarsColorId(int colorId);

    }
}
