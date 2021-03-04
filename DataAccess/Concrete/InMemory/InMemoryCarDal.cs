using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal

    {
    List<Car> _cars;

    public InMemoryCarDal()
    {
        _cars = new List<Car>()
        {
            new Car()
            {
                CarId = 1, BrandId = 2, ColorId = 3, DailyPrice = 1555, Description = "Audi", ModelYear = "2015"
            },
            new Car() {CarId = 2, BrandId = 1, ColorId = 1, DailyPrice = 200, Description = "Uno", ModelYear = "1995"},
            new Car()
            {
                CarId = 3, BrandId = 3, ColorId = 2, DailyPrice = 6000, Description = "Pagani", ModelYear = "2015"
            },
            new Car()
            {
                CarId = 4, BrandId = 4, ColorId = 3, DailyPrice = 100, Description = "Renault", ModelYear = "2015"
            }
        };

    }

    public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
    {
        throw new NotImplementedException();
    }

    public Car Get(Expression<Func<Car, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public void Add(Car car)
    {
        _cars.Add(car);
    }

    public void Update(Car car)
    {
        Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
        if (carToUpdate != null)
        {

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }

    public void Delete(Car car)
    {
        Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
        _cars.Remove(carToDelete);
    }

    public List<CarDetailDto> GetCarDetails()
    {
        throw new NotImplementedException();
    }
    }
}
