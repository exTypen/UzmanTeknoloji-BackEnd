using System.Collections.Generic;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll());
        }

        public IDataResult<Order> Get(int id)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(o => o.Id == id));
        }

        public IResult Add(Order entity)
        {
            _orderDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Order entity)
        {
            _orderDal.Delete(entity);
            return new SuccessResult();
        }

        public IResult Update(Order entity)
        {
            _orderDal.Update(entity);
            return new SuccessResult();
        }

        public IDataResult<long> GetIdAdd(Order order)
        {
            _orderDal.Add(order);
            return new SuccessDataResult<long>(order.Id);
        }

        public IDataResult<List<OrderDto>> GetOrderDetailsByUser(int userId)
        {
            return new SuccessDataResult<List<OrderDto>>(_orderDal.GetAllOrderDetails(o=>o.UserId == userId));
        }
    }
}