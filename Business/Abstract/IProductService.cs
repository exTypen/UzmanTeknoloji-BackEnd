using System.Collections.Generic;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<ProductDto>> GetAllProductDetails();
        IDataResult<List<ProductDto>> GetAllProductDetailsByCategory(int categoryId);
        IDataResult<List<ProductDto>> GetAllProductDetailsByBrand(int brandId);
        IDataResult<List<Product>> GetAllByCategory(int categoryId);
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);
    }
}