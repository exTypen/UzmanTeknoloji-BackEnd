using System.Collections.Generic;
using Business.Generics;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IOrderService : IGenericService<Order>
    {
        IDataResult<long> GetIdAdd(Order order);
        IDataResult<List<OrderDto>> GetOrderDetailsByUser(int userId);
    }
}