using FiapCloud.Games.App.common;
using Microsoft.AspNetCore.Mvc;

namespace FiapCloud.Games.Api.Controllers;

public abstract class BaseController : ControllerBase
{
    protected IActionResult FromResult<T>(Result<T> result)
    {
        if (result.Success)
            return Ok(result.Data);

        return BadRequest(result);
    }
}
