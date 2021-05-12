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
        IDataResult<List<Product>> GetAllByCategory(int categoryId);
        IDataResult<List<ProductDto>> GetAllProductDetails();
        IDataResult<List<ProductDto>> GetAllProductDetailsFilter(ProductDetailFilterDto filterDto);
        IDataResult<List<ProductDto>> GetAllProductDetailsWithPage(int page, int pageSize);
        IDataResult<List<ProductDto>> GetLimitedProductDetails(int limit);
        IDataResult<List<ProductDto>> GetAllProductDetailsById(int id);
        IDataResult<List<ProductDto>> GetAllProductDetailsByCategory(int categoryId);
        IDataResult<List<ProductDto>> GetLimitedProductDetailsByCategory(int categoryId, int limit);
        IDataResult<List<ProductDto>> GetAllProductDetailsByCategoryWithPage(int categoryId, int page, int pageSize);
        IDataResult<List<ProductDto>> GetAllProductDetailsByBrand(int brandId);
        IDataResult<List<ProductDto>> GetLimitedProductDetailsByBrand(int brandId, int limit);
        IDataResult<List<ProductDto>> GetAllProductDetailsFilteredWithPage(int brandId, int categoryId, int page, int pageSize);
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);
    }
}