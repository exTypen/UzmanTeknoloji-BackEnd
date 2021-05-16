﻿using System.Collections.Generic;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Business.Generics
{
    public interface IGenericImagesService<T>
    {
        IResult Add(IFormFile file, T entity);
        IResult Delete(T entity);
        IResult Update(IFormFile file, T entity);
        IDataResult<T> Get(int id);
        IDataResult<List<T>> GetAll();

    }
}