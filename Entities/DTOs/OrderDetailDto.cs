using System;
using Core.Entities;

namespace Entities.DTOs
{
    public class OrderDetailDto : IDto
    {
        public Int64 Id { get; set; }
        public Int64 OrderId { get; set; }
        public ProductDto ProductDto { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }
}