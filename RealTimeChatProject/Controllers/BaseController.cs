using MainData.Entities;
using MainData.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[Controller]")]
public class BaseController : ControllerBase
{
    
}