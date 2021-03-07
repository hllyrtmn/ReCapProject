﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constraint.Message;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
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

        public IDataResult<List<Brand>>  GetAll()
        {


            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandListed);
        }

        public IResult Add(Brand business)
        {
            _brandDal.Add(business);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand business)
        {
            _brandDal.Delete(business);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IResult Update(Brand business)
        {
            _brandDal.Update(business);
            return new SuccessResult(Messages.BrandUpdated);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b=>b.BrandId==id),Messages.BrandById);
        }
    }
}
