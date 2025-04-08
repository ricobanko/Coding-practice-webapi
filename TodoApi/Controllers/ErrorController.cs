using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers;

[ApiController]
[Route("error")]
public class errorController : Controller
{
    public IActionResult HandleError()
    {
        return Problem("An unexpected error occurred.  Please try again later");
    }
}
