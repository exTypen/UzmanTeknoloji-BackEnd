using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, UzmanContext>, IProductDal
    {
        public List<ProductDto> GetAllProductDetails(Expression<Func<Product, bool>> filter = null)
        {
            using (UzmanContext context = new UzmanContext())
            {
                var result = from product in filter == null ? context.Products : context.Products.Where(filter)
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
                    };
                return result.ToList();
            }
        }
    }
}