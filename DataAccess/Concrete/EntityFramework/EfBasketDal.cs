using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete
{
    public class EfBasketDal : EfEntityRepositoryBase<Basket, UzmanContext>, IBasketDal
    {
        public List<BasketDto> GetAllBasketDetails(Expression<Func<Basket, bool>> filter = null)
        {
            using (UzmanContext context = new UzmanContext())
            {
                var result = from basket in filter == null ? context.Baskets : context.Baskets.Where(filter)
                    join product in context.Products
                        on basket.ProductId equals product.Id
                        
                    select new BasketDto()
                    {
                        Id = basket.Id,
                        ProductDetails = (from p in context.Products where p.Id == product.Id
                            join brand in context.Brands
                                on product.BrandId equals brand.Id
                            join category in context.Categories
                                on product.CategoryId equals category.Id

                            select new ProductDto()
                            {
                                Id = product.Id,

                                CategoryId = product.CategoryId,

                                CategoryName = category.Name,

                                BrandId = product.BrandId,

                                BrandName = brand.Name,

                                Name = product.Name,

                                Code = product.Code,

                                Price = product.Price,
                        
                                Images = (from i in context.ProductImages where i.ProductId == product.Id select i.ImagePath).ToList(),

                                CreateDate = product.CreateDate,

                                Active = product.Active
                            }).ToList()[0],
                        userId = basket.UserId,
                        Count = basket.Count,
                        CreateDate = basket.CreateDate,
                        Active = basket.Active
                    };
                return result.ToList();
            }
        }
    }
}