using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IProductImageService
    {
        IDataResult<ProductImage> Get(int id);
        IDataResult<List<ProductImage>> GetAll();
        IDataResult<List<ProductImage>> GetAllByProduct(int productId);
        IResult Add(IFormFile file, ProductImage productImage);
        IResult Delete(ProductImage productImage);
        IResult Update(IFormFile file, ProductImage productImage);
    }
}