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
        IDataResult<List<ProductDto>> GetLimitedProductDetails(int limit);
        IDataResult<List<ProductDto>> GetAllProductDetailsById(int id);
        IDataResult<List<ProductDto>> GetAllProductDetailsByCategory(int categoryId);
        IDataResult<List<ProductDto>> GetLimitedProductDetailsByCategory(int categoryId, int limit);
        IDataResult<List<ProductDto>> GetAllProductDetailsByBrand(int brandId);
        IDataResult<List<ProductDto>> GetLimitedProductDetailsByBrand(int brandId, int limit);
        IDataResult<List<Product>> GetAllByCategory(int categoryId);
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);
    }
}