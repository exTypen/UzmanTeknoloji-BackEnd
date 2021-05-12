using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        User GetByMail(string email);
        IResult Update(User user);
        IDataResult<List<OperationClaim>> GetClaims(User user);
    }
}