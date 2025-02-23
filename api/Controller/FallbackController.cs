using Microsoft.AspNetCore.Mvc;


[Route("[controller]")]
public class FallbackController : Controller

{

    [HttpGet("/")]
    public IActionResult Index()
    {
        return PhysicalFile(
            Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                "index.html"),
                "text/HTML"
        );
    }
}
