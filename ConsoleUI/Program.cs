using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Concrete;
using Core.DataAccess.EntityFramework;
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
            //UserAddTest();
            //CustomerAddTest();

            //RentalAdd();

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Update(new Rental{RentalId = 1,ReturnDate = DateTime.Today,CarId = 2,CustomerId = 2,RentDate = DateTime.Now});
        }

        private static void RentalAdd()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            rentalManager.Add(new Rental() {CustomerId = 1, CarId = 2, RentDate = DateTime.Now});
        }

        private static void CustomerAddTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer()
            {
                CompanyName = "HalilCompany",
                UserId = 1
            });
            customerManager.Add(new Customer()
            {
                CompanyName = "GulCompany",
                UserId = 2
            });
        }
        private static void UserAddTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User()
            {
                FirstName = "Fatma Gül",
                LastName = "Altun",
                Email = "fgul@hotmail.com",
                Password = "123234567"
            });
        }

        private static void GetCarFullDetail( )
        {
            ICarService carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.BrandName + " " + car.Description + " "
                                  + car.ColorName + " " + car.ModelYear + " " + car.DailyPrice);
            }
        }

        private static void GetByColorId()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsColorId(1).Data)
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void AddCar()
        {
            ICarService carManager = new CarManager(new EfCarDal());
            //IBrandService brandService = new BrandManager(new EfBrandDal());
            //IColorService colorService = new ColorManager(new EfColorDal());

            Car car = new Car() {BrandId = 3, ColorId = 1, DailyPrice = 200, Description = "T", ModelYear = "2009"};

            carManager.Add(car);

            foreach (var item in carManager.GetAll().Data)
            {
                System.Console.WriteLine(item.Description);
            }
        }
    }
}
