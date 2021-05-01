using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IBannerService
    {
        IDataResult<List<Banner>> GetAll();
        IResult Add(IFormFile file, Banner banner);
        IResult Delete(Banner banner);
        IResult Update(IFormFile file, Banner banner);
        
    }
}