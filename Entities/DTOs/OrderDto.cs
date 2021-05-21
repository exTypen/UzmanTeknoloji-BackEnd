using System;
using System.Collections.Generic;
using Core.Entities;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class OrderDto : IDto
    {
        public Int64 Id { get; set; }
        public User User { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public Address Address { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }
}