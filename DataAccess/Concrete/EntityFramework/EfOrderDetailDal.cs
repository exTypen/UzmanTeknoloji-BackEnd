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
    public class EfOrderDetailDal : EfEntityRepositoryBase<OrderDetail, UzmanContext>, IOrderDetailDal
    {
        public List<OrderDetailDto> GetAllOrderDetailDtos(Expression<Func<OrderDetail, bool>> filter = null)
        {
            using (UzmanContext context = new UzmanContext())
            {
                var result =
                    from orderDetail in filter == null ? context.OrderDetails : context.OrderDetails.Where(filter)
                    select new OrderDetailDto()
                    {
                        Id = orderDetail.Id,
                        OrderId = orderDetail.Id,
                        ProductDto = (from p in context.Products
                            where p.Id == orderDetail.ProductId
                            join brand in context.Brands
                                on p.BrandId equals brand.Id
                            join category in context.Categories
                                on p.CategoryId equals category.Id

                            select new ProductDto()
                            {
                                Id = p.Id,

                                CategoryId = p.CategoryId,

                                CategoryName = category.Name,

                                BrandId = p.BrandId,

                                BrandName = brand.Name,

                                Name = p.Name,

                                Code = p.Code,

                                Price = p.Price,

                                Images = (from i in context.ProductImages
                                    where i.ProductId == p.Id
                                    select i.ImagePath).ToList(),

                                CreateDate = p.CreateDate,

                                Active = p.Active
                            }).ToList()[0],
                        Count = orderDetail.Count,
                        Price = orderDetail.Price,
                        CreateDate = orderDetail.CreateDate,
                        Active = orderDetail.Active
                    };
                return result.ToList();
            }
        }
    }
}