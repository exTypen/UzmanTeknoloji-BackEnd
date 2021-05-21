using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public Int64 Id { get; set; }
        public int UserId { get; set; }
        public Int64 AddressId { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
        
    }
}