using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, UzmanContext>, IOrderDal
    {
        public List<OrderDto> GetAllOrderDetails(Expression<Func<Order, bool>> filter = null)
        {
            using (UzmanContext context = new UzmanContext())
            {
                var result = from order in filter == null ? context.Orders : context.Orders.Where(filter)
                    join user in context.Users
                        on order.UserId equals user.Id
                    join address in context.Addresses
                        on order.AddressId equals address.Id

                    select new OrderDto()
                    {
                        Id = order.Id,
                        User = user,
                        OrderDetails = (from o in context.OrderDetails where o.OrderId == order.Id select o).ToList(),
                        Address = address,
                        OrderStatusId = order.OrderStatusId,
                        CreateDate = order.CreateDate,
                        Active = order.Active
                    };
                return result.ToList();
            }
        }
    }
}