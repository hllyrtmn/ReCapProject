using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,ReCapDbContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from car in context.Cars
                    join brand in context.Brands
                        on car.BrandId equals brand.BrandId
                    join color in context.Colors
                        on car.ColorId equals color.ColorId
                    select new CarDetailDto()
                    {
                        BrandName = brand.BrandName, Description = car.Description, ColorName = color.ColorName,
                        DailyPrice = car.DailyPrice, ModelYear = car.ModelYear
                    };
                return result.ToList();
            }
        }
    }
}
