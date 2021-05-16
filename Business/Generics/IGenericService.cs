﻿using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Generics
{
    public interface IGenericService<T>
    {
        IDataResult<List<T>> GetAll();
        IResult Add(T entity);
        IResult Delete(T entity);
        IResult Update(T entity);
    }
}