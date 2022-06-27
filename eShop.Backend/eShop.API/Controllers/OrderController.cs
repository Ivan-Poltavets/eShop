using eShop.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eShop.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
            => _orderService = orderService;

        [HttpGet]
        [Route("orders")]
        public async Task<IActionResult> GetOrders()
            => Ok(await _orderService.GetOrdersAsync(UserId));

        [HttpGet]
        [Route("orders/{id}")]
        public async Task<IActionResult> GetOrder(Guid id)
            => Ok(await _orderService.GetOrderAsync(id, UserId));
    }
}
