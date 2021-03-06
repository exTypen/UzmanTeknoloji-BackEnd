using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IBasketDal : IEntityRepository<Basket>
    {
        List<BasketDto> GetAllBasketDetails(Expression<Func<Basket, bool>> filter = null);
    }
}