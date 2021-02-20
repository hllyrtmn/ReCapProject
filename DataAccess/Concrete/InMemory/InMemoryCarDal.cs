using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        private List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car(){Id = 1,BrandId = 2,ColorId = 3,DailyPrice = 1555,Description = "Audi",ModelYear = "2015"},
                new Car(){Id = 2,BrandId = 1,ColorId = 1,DailyPrice = 200,Description = "Uno",ModelYear = "1995"},
                new Car(){Id = 3,BrandId = 3,ColorId = 2,DailyPrice = 6000,Description = "Pagani",ModelYear = "2015"},
                new Car(){Id = 4,BrandId = 4,ColorId = 3,DailyPrice = 100,Description = "Renault",ModelYear = "2015"}
            };

        }
        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
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
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

    }
}
