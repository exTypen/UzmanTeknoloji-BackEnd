using System.Collections.Generic;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        private IOrderDetailDal _orderDetailDal;

        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }

        public IDataResult<List<OrderDetail>> GetAll()
        {
            return new SuccessDataResult<List<OrderDetail>>(_orderDetailDal.GetAll());
        }

        public IDataResult<OrderDetail> Get(int id)
        {
            return new SuccessDataResult<OrderDetail>(_orderDetailDal.Get(o => o.Id == id));
        }

        public IResult Add(OrderDetail entity)
        {
            _orderDetailDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(OrderDetail entity)
        {
            _orderDetailDal.Delete(entity);
            return new SuccessResult();
        }

        public IResult Update(OrderDetail entity)
        {
            _orderDetailDal.Update(entity);
            return new SuccessResult();
        }

        public IResult MultiAdd(OrderDetail[] orderDetails)
        {
            _orderDetailDal.MultiAdd(orderDetails);
            return new SuccessResult();
        }
    }
}