using Business.Generics;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IOrderDetailService : IGenericService<OrderDetail>
    {
        IResult MultiAdd(OrderDetail[] orderDetails);
    }
}