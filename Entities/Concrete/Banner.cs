
using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class Banner : IEntity
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string UrlPath { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }
}