using System.Collections.Generic;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll());
        }

        public IDataResult<List<ProductDto>> GetAllProductDetails()
        {
            return new SuccessDataResult<List<ProductDto>>(_productDal.GetAllProductDetails());
        }

        public IDataResult<List<ProductDto>> GetAllProductDetailsByCategory(int categoryId)
        {
            return new SuccessDataResult<List<ProductDto>>(_productDal.GetAllProductDetails(p => p.CategoryId == categoryId));
        }

        public IDataResult<List<ProductDto>> GetAllProductDetailsByBrand(int brandId)
        {
            return new SuccessDataResult<List<ProductDto>>(_productDal.GetAllProductDetails(p => p.BrandId == brandId));
        }

        public IDataResult<List<Product>> GetAllByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == categoryId));
        }

        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult();
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult();
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult();
        }
    }
}