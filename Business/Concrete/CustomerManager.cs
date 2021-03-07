using System;
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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }


        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.RentalListed);

        }

        public IResult Add(Customer business)
        {
            _customerDal.Add(business);
            return new SuccessResult(Messages.RentalAdded);

        }

        public IResult Delete(Customer business)
        {
            _customerDal.Delete(business);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IResult Update(Customer business)
        {
            _customerDal.Update(business);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(r => r.CustomerId == id));
        }
    }
}
