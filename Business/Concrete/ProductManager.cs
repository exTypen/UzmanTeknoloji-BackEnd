using System;
using System.Collections.Generic;
using System.Linq;
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

        public IDataResult<List<ProductDto>> GetAllProductDetailsWithPage(int page, int pageSize)
        {
            return new SuccessDataResult<List<ProductDto>>(_productDal.GetAllProductDetails().Skip((page-1)*pageSize).Take(pageSize).ToList());
        }

        public IDataResult<List<ProductDto>> GetLimitedProductDetails(int limit)
        {
            return new SuccessDataResult<List<ProductDto>>(_productDal.GetAllProductDetails().Take(limit).ToList());
        }


        public IDataResult<List<ProductDto>> GetAllProductDetailsById(int id)
        {
            return new SuccessDataResult<List<ProductDto>>(_productDal.GetAllProductDetails(p => p.Id == id));
        }

        public IDataResult<List<ProductDto>> GetAllProductDetailsByCategory(int categoryId)
        {
            return new SuccessDataResult<List<ProductDto>>(_productDal.GetAllProductDetails(p => p.CategoryId == categoryId));
        }

        public IDataResult<List<ProductDto>> GetLimitedProductDetailsByCategory(int categoryId, int limit)
        {
            return new SuccessDataResult<List<ProductDto>>(_productDal
                .GetAllProductDetails(p => p.CategoryId == categoryId).Take(limit).ToList());
        }

        public IDataResult<List<ProductDto>> GetAllProductDetailsByCategoryWithPage(int categoryId, int page, int pageSize)
        {
            return new SuccessDataResult<List<ProductDto>>(_productDal
                .GetAllProductDetails(p => p.CategoryId == categoryId).Skip((page - 1) * pageSize).Take(pageSize)
                .ToList());
        }


        public IDataResult<List<ProductDto>> GetAllProductDetailsByBrand(int brandId)
        {
            return new SuccessDataResult<List<ProductDto>>(_productDal.GetAllProductDetails(p => p.BrandId == brandId));
        }

        public IDataResult<List<ProductDto>> GetLimitedProductDetailsByBrand(int brandId, int limit)
        {
            return new SuccessDataResult<List<ProductDto>>(_productDal.GetAllProductDetails(p => p.BrandId == brandId)
                .Take(limit).ToList());
        }

        public IDataResult<List<ProductDto>> GetAllProductDetailsFilteredWithPage(int brandId, int categoryId, int page, int pageSize)
        {
            if (brandId == 0 && categoryId == 0)
            {
                return new SuccessDataResult<List<ProductDto>>(_productDal.GetAllProductDetails().Skip((page-1)*pageSize).Take(pageSize).ToList());
            }
            
            if (brandId == 0)
            {
                return new SuccessDataResult<List<ProductDto>>(
                    _productDal.GetAllProductDetails(p => p.CategoryId == categoryId).Skip((page-1)*pageSize).Take(pageSize).ToList());
            }

            if (categoryId == 0)
            {
                return new SuccessDataResult<List<ProductDto>>(
                    _productDal.GetAllProductDetails(p => p.BrandId == brandId).Skip((page-1)*pageSize).Take(pageSize).ToList());
            }

            return new SuccessDataResult<List<ProductDto>>(
                _productDal.GetAllProductDetails(p => p.CategoryId == categoryId && p.BrandId == brandId).Skip((page-1)*pageSize).Take(pageSize).ToList());
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
