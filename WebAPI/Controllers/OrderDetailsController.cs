using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderDetailsController : Controller
    {
        private IOrderDetailService _orderDetailService;

        public OrderDetailsController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpPost("MultiAdd")]
        public IActionResult MultiAdd(OrderDetail[] orderDetails)
        {
            var result = _orderDetailService.MultiAdd(orderDetails);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}