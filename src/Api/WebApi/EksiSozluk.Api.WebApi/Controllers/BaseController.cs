using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.Api.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    public Guid? UserId
    {
        get
        {
            var value = HttpContext.User.Claims;

            return value is null ? null : new Guid();
        }
    }
}