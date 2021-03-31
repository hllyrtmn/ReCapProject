using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IResult Add(Color business);
        IResult Delete(Color business);
        IResult Update(Color business);
        IDataResult<Color> GetById(int id);
    }
}