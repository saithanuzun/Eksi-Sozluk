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
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            
            if (identity is not null)
            {
                var userClaims = identity.Claims;
                var id = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value;
                return new Guid(id);
            }
            return null;
        }
    }
}