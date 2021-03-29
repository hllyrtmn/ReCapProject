using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService : IBusinessRepository<User>
    {
        IDataResult<List<UserForRegisterDto>> GetUserForRegister();
        IDataResult<User>  GetByMail(string email);
        List<OperationClaim> GetClaims(User user);
    }
}