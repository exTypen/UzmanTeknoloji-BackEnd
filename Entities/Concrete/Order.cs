using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public Int64 Id { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public int OrderStatusId { get; set; }
        public int Count { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
        
    }
}