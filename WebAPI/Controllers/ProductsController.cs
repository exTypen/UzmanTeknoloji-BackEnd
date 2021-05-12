using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        
        [HttpGet("GetAllProductDetails")]
        public IActionResult GetAllProductDetails()
        {
            var result = _productService.GetAllProductDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        
        [HttpGet("GetAllProductDetailsByFilter")]
        public IActionResult GetAllProductDetailsByFilter([FromQuery]ProductDetailFilterDto filterDto)
        {
            var result = _productService.GetAllProductDetailsFilter(filterDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        
        [HttpGet("GetAllProductDetailsByPage")]
        public IActionResult GetAllProductDetailsByPage(int page, int pageSize)
        {
            var result = _productService.GetAllProductDetailsWithPage(page, pageSize);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        

        [HttpGet("GetLimitedProductDetails")]
        public IActionResult GetLimitedProductDetails(int limit)
        {
            var result = _productService.GetLimitedProductDetails(limit);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        
        [HttpGet("GetAllProductDetailsById")]
        public IActionResult GetAllProductDetailsById(int id)
        {
            var result = _productService.GetAllProductDetailsById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        
        [HttpGet("GetAllByCategory")]
        public IActionResult GetAllByCategory(int id)
        {
            var result = _productService.GetAllByCategory(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        
        [HttpGet("GetAllProductDetailsFilteredByPage")]
        public IActionResult GetAllProductDetailsFilteredByPage(int brandId, int categoryId, int page, int pageSize)
        {
            var result = _productService.GetAllProductDetailsFilteredWithPage(brandId, categoryId, page, pageSize);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        
        [HttpGet("GetLimitedProductDetailsByCategory")]
        public IActionResult GetLimitedProductDetailsByCategory(int id, int limit)
        {
            var result = _productService.GetLimitedProductDetailsByCategory(id, limit);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}