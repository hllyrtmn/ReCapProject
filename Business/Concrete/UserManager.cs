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
    public class UserManager : IUserService
    { 
        IUserDal _userDal;
        IRulesService _rulesService;

        public UserManager(IUserDal userDal, IRulesService rulesService)
        {
            _userDal = userDal;
            _rulesService = rulesService;
        }


        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }

        public IResult Add(User business)
        {
            _userDal.Add(business);
           return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User business)
        {
            _userDal.Delete(business);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IResult Update(User business)
        {
            _userDal.Update(business);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == id));
        }
    }
}
