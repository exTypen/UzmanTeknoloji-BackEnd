using System.Collections.Generic;
using Core.Entities;
using Core.Utilities.Attributes.FilterAttributes;

namespace Entities.DTOs
{
    public class ProductDetailFilterDto : IFilterDto
    {
        [EqualFilter("Id")]
        public List<int> Id { get; set; }
        [EqualFilter("BrandId")]
        public List<int> BrandId { get; set; }
        [EqualFilter("CategoryId")]
        public List<int> CategoryId { get; set; }
        [MinFilter("Price")]
        public decimal? MinPrice { get; set; }
        [MaxFilter("Price")]
        public decimal? MaxPrice { get; set; }
    }
}