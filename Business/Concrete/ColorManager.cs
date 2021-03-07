﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constraint.Message;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IDataResult<List<Color>> GetAll()
        {
           return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.ColorListed);
        }

        public IResult Add(Color business)
        {
            _colorDal.Add(business);

            return new SuccessResult( Messages.ColorAdded);
        }

        public IResult Delete(Color business)
        {
            _colorDal.Delete(business);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IResult Update(Color business)
        {
            _colorDal.Update(business);
            return new SuccessResult(Messages.ColorUpdated);
        }

        public IDataResult<Color>  GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == id), Messages.ColorById);
        }
    }
}
