using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail()
        {
            using (ReCapDbContext db = new ReCapDbContext())
            {
                var result = from rental in db.Rentals
                             join car in db.Cars on rental.CarId equals car.CarId
                             join brand in db.Brands on car.BrandId equals brand.BrandId
                             join customer in db.Customers on rental.CustomerId equals customer.CustomerId
                             join user in db.Users on customer.UserId equals user.UserId
                             select new RentalDetailDto()
                             {
                                 BrandName = brand.BrandName,
                                 Description = car.Description,
                                 CustomerFullName = $"{user.FirstName} {user.LastName}",
                                 RentalId = rental.RentalId,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
