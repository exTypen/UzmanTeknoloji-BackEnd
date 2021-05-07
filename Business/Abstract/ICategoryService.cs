using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<List<Category>> GetById(int id);
        IResult Add(Category category);
        IResult Delete(Category category);
        IResult Update(Category category);
    }
}