﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductDto> GetAllProductDetails(Expression<Func<Product, bool>> filter = null);
    }
}