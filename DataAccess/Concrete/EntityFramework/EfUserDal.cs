using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapDbContext>, IUserDal
    {
        //public List<UserForRegisterDto> GetUserForRegister()
        //{
        //    using (var context = new ReCapDbContext())
        //    {
        //        var result = from user in context.Users
        //            select new UserForRegisterDto()
        //            {
        //                FirstName = user.FirstName,
        //                LastName = user.LastName,
        //                Password = user.Password,
        //                Email = user.Email
        //            };
        //        return result.ToList();
        //    }
            
        //}

        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ReCapDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                    join userOperationClaim in context.UserOperationClaims on operationClaim.Id equals userOperationClaim.OperationClaimId
                    where userOperationClaim.UserId == user.UserId 
                    select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }

    }
}
