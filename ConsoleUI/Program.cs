using System;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // AddCar();
            // GetByColorId();
            //GetCarFullDetail();
        }

        private static void GetCarFullDetail()
        {
            CarManager carManager = new CarManager(new EfCarDal(), new RuleManager());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.BrandName + " " + car.Description + " "
                                  + car.ColorName + " " + car.ModelYear + " " + car.DailyPrice);
            }
        }

        private static void GetByColorId()
        {
            CarManager carManager = new CarManager(new EfCarDal(), new RuleManager());
            foreach (var car in carManager.GetCarsColorId(1))
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void AddCar()
        {
            ICarService carManager = new CarManager(new EfCarDal(), new RuleManager());
            //IBrandService brandService = new BrandManager(new EfBrandDal());
            //IColorService colorService = new ColorManager(new EfColorDal());

            Car car = new Car() {BrandId = 3, ColorId = 1, DailyPrice = 200, Description = "T", ModelYear = "2009"};

            carManager.Add(car);

            foreach (var item in carManager.GetAll())
            {
                System.Console.WriteLine(item.Description);
            }
        }
    }
}
