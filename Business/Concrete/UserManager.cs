using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constant.Message;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class UserManager : IUserService
    { 
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [CacheAspect]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }

        [ValidationAspect(typeof(UserValidator))]
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

        public IDataResult<List<UserForRegisterDto>> GetUserForRegister()
        {
            return new SuccessDataResult<List<UserForRegisterDto>>();
        }

        public IDataResult<User>  GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
    }
}
