using eShop.Application.Interfaces;
using eShop.Domain.Entities;
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
        public async Task<ActionResult<List<Order>>> GetOrders() 
            => await _orderService.GetOrdersAsync(UserId);

        [HttpGet]
        [Route("orders/{id}")]
        public async Task<ActionResult<List<OrderItem>>> GetOrder(Guid id)
            => await _orderService.GetOrderAsync(id, UserId);

        [HttpPost]
        [Route("orders")]
        public async Task<IActionResult> CreateOrder()
        {
            var result = await _orderService.CreateAsync(UserId);
            return CreatedAtAction(nameof(CreateOrder), result);
        }
    }
}
