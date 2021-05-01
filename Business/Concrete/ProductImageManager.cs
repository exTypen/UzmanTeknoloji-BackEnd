using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        private IProductImageDal _productImageDal;

        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }

        public IDataResult<ProductImage> Get(int id)
        {
            return new SuccessDataResult<ProductImage>(_productImageDal.Get(i => i.Id == id));
        }

        public IDataResult<List<ProductImage>> GetAll()
        {
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll());
        }

        public IDataResult<List<ProductImage>> GetAllByProduct(int productId)
        {
            IResult result = BusinessRules.Run(CheckIfProductImageNull(productId));

            if (result != null)
            {
                return new ErrorDataResult<List<ProductImage>>(result.Message);
            }

            return new SuccessDataResult<List<ProductImage>>(CheckIfProductImageNull(productId).Data);
        }

        public IResult Add(IFormFile file, ProductImage productImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(productImage.ProductId));
            if (result != null)
            {
                return result;
            }

            productImage.ImagePath = FileHelper.Add(file);
            productImage.CreateDate = DateTime.Now;
            productImage.Active = true;
            _productImageDal.Add(productImage);
            return new SuccessResult();
        }

        public IResult Delete(ProductImage productImage)
        {
            FileHelper.Delete(productImage.ImagePath);
            _productImageDal.Delete(productImage);
            return new SuccessResult();
        }

        public IResult Update(IFormFile file, ProductImage productImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(productImage.ProductId));
            if (result != null)
            {
                return result;
            }

            var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _productImageDal.Get(p => p.Id == productImage.Id).ImagePath;

            productImage.ImagePath = FileHelper.Update(oldPath, file);
            productImage.CreateDate = DateTime.Now;
            productImage.Active = true;
            _productImageDal.Update(productImage);
            return new SuccessResult();
        }
        
        private IDataResult<List<ProductImage>> CheckIfProductImageNull(int id)
        {
            try
            {
                string path = @"\uploads\default.jpg";
                var result = _productImageDal.GetAll(i => i.ProductId == id).Any();
                if (!result)
                {
                    List<ProductImage> productImage = new List<ProductImage>();
                    productImage.Add(new ProductImage { ProductId = id, ImagePath = path, CreateDate = DateTime.Now });
                    return new SuccessDataResult<List<ProductImage>>(productImage);
                }
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<ProductImage>>(exception.Message);
            }
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll(i => i.ProductId == id));
        }
        
        private IResult CheckImageLimitExceeded(int productId) 
        {
            var productImageCount = _productImageDal.GetAll(i => i.ProductId == productId).Count;
            if (productImageCount >= 5)
            {
                return new ErrorResult(Messages.ProductImageLimitExceeded);
            }

            return new SuccessResult();
        }
    }
}