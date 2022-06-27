using eShop.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShop.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
            => _orderService = orderService;

        [HttpGet]
        public async Task<IActionResult> GetOrders()
            => Ok(await _orderService.GetOrdersAsync(UserId));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(Guid id)
            => Ok(await _orderService.GetOrderAsync(id, UserId));
    }
}
