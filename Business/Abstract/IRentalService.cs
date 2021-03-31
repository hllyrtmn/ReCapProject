using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IResult Add(Rental business);
        IResult Delete(Rental business);
        IResult Update(Rental business);
        IDataResult<Rental> GetById(int id);
    }
}