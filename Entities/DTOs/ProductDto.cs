using System;
using System.Collections.Generic;
using Core.Entities;

namespace Entities.DTOs
{
    public class ProductDto : IDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public List<string> Images { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }
}