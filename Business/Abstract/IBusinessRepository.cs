using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;

namespace Business.Abstract
{
    public interface IBusinessRepository<T> where T : class, new()
    {
        IDataResult<List<T>> GetAll();
        IResult Add(T business);
        IResult Delete(T business);
        IResult Update(T business);
        IDataResult<T> GetById(int id);


    }
}
