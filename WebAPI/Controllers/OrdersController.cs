using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : Controller
    {
        private IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("GetIdAdd")]
        public IActionResult GetIdAdd(Order order)
        {
            var result = _orderService.GetIdAdd(order);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetAllDetailsByUser")]
        public IActionResult GetAllDetailsByUser(int userId)
        {
            var result = _orderService.GetOrderDetailsByUser(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}