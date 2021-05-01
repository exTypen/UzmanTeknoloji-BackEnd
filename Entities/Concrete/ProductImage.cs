using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class ProductImage : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImagePath { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool Active { get; set; }
    }
}