using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketsController : Controller
    {
        private IBasketService _basketService;

        public BasketsController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Basket basket)
        {
            var result = _basketService.Add(basket);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        
        [HttpGet("GetAll")] 
        public IActionResult GetAll()
        {
            var result = _basketService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetAllDetailsByUser")]
        public IActionResult GetAllDetailsByUser(int userId)
        {
            var result = _basketService.GetAllDetailsByUser(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);  
        }
        
        [HttpPost("Delete")]
        public IActionResult Delete(Basket basket)
        {
            var result = _basketService.Delete(basket);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("DeleteByUser")]
        public IActionResult DeleteByUser(int userId)
        {
            var result = _basketService.DeleteByUser(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}