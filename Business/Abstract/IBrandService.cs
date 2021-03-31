using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService 
    {
        IDataResult<List<Brand>> GetAll();
        IResult Add(Brand business);
        IResult Delete(Brand business);
        IResult Update(Brand business);
        IDataResult<Brand> GetById(int id);

    }
}