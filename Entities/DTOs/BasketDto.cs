using System;
using Core.Entities;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class BasketDto : IDto
    {
        public Int64 Id { get; set; }
        public ProductDto ProductDetails { get; set; }
        public int userId { get; set; }
        public int Count { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }
}