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
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDbContext>, ICarDal
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
                                 CarId = car.CarId,
                                 BrandName = brand.BrandName,
                                 Description = car.Description,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 Detail = car.Detail,
                                 ImagePath = context.CarImages.Where(c => c.CarId == car.CarId).FirstOrDefault().ImagePath

                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsBrand(int brandId)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                                 on car.BrandId equals brand.BrandId
                             join color in context.Colors
                                 on car.ColorId equals color.ColorId
                             
                             where brand.BrandId == brandId
                             select new CarDetailDto()
                             {
                                 CarId = car.CarId,
                                 BrandName = brand.BrandName,
                                 Description = car.Description,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 Detail = car.Detail,
                                 ImagePath = (from carImage in context.CarImages where carImage.CarId == car.CarId select carImage.ImagePath).FirstOrDefault()

                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsColor(int colorId)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                                 on car.BrandId equals brand.BrandId
                             join color in context.Colors
                                 on car.ColorId equals color.ColorId
                          
                             where color.ColorId == colorId
                             select new CarDetailDto()
                             {
                                 CarId = car.CarId,
                                 BrandName = brand.BrandName,
                                 Description = car.Description,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 Detail = car.Detail,
                                 ImagePath = (from carImage in context.CarImages where carImage.CarId == car.CarId select carImage.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }
        public CarDetailDto GetCarDetailsById(int carId)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from car in context.Cars
                    join brand in context.Brands
                        on car.BrandId equals brand.BrandId
                    join color in context.Colors
                        on car.ColorId equals color.ColorId
                    where car.CarId == carId

                    select new CarDetailDto()
                    {
                        CarId = car.CarId,
                        BrandName = brand.BrandName,
                        Description = car.Description,
                        ColorName = color.ColorName,
                        DailyPrice = car.DailyPrice,
                        ModelYear = car.ModelYear,
                        Detail = car.Detail,
                        ImagePath = (from carImage in context.CarImages where carImage.CarId == car.CarId select carImage.ImagePath).FirstOrDefault()
                    };
                return result.SingleOrDefault();
            }
        }

        public List<CarDetailDto> GetCarFilterByColorBrand(int colorId, int brandId)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from car in context.Cars
                    join brand in context.Brands
                        on car.BrandId equals brand.BrandId
                    join color in context.Colors
                        on car.ColorId equals color.ColorId
                    where ((color.ColorId == colorId)&& (brand.BrandId ==brandId))

                    select new CarDetailDto()
                    {
                        CarId = car.CarId,
                        BrandName = brand.BrandName,
                        Description = car.Description,
                        ColorName = color.ColorName,
                        DailyPrice = car.DailyPrice,
                        ModelYear = car.ModelYear,
                        Detail = car.Detail,
                        ImagePath = (from carImage in context.CarImages where carImage.CarId == car.CarId select carImage.ImagePath).FirstOrDefault()
                    };
                return result.ToList();
            }
        }
    }
}
