using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constant.Message;
using Core.Aspects.Autofac.Caching;
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

        [CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomerListed);

        }

        public IResult Add(Customer business)
        {
            _customerDal.Add(business);
            return new SuccessResult(Messages.CustomerAdded);

        }

        public IResult Delete(Customer business)
        {
            _customerDal.Delete(business);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IResult Update(Customer business)
        {
            _customerDal.Update(business);
            return new SuccessResult(Messages.CustomerUpdated);
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(r => r.CustomerId == id));
        }
    }
}
