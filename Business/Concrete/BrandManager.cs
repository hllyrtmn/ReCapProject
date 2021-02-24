using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;

        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public void Add(Brand business)
        {
            _brandDal.Add(business);
        }

        public void Delete(Brand business)
        {
            _brandDal.Delete(business);
        }

        public void Update(Brand business)
        {
            _brandDal.Update(business);
        }

        public Brand GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
