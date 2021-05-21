using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class OrderDetail : IEntity
    {
        public Int64 Id { get; set; }
        public Int64 OrderId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }
}