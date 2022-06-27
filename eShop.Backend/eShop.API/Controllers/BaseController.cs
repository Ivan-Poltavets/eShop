using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        internal Guid UserId => !User.Identity.IsAuthenticated
            ? Guid.Empty
            : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}
