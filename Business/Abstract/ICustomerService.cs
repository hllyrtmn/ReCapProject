using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IResult Add(Customer business);
        IResult Delete(Customer business);
        IResult Update(Customer business);
        IDataResult<Customer> GetById(int id);

    }
}