using System.Collections.Generic;
using Business.Generics;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IBasketService : IGenericService<Basket>
    {
        IDataResult<List<BasketDto>> GetAllDetailsByUser(int userId);
        IResult DeleteByUser(int userId);
    }
}