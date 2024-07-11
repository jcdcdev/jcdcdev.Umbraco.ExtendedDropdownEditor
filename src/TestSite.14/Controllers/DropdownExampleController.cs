using Microsoft.AspNetCore.Mvc;

namespace TestSite.Fourteen.Controllers;

[Route("/api")]
public class DropdownExampleController : Controller
{
    [Route("cats")]
    public IActionResult Get()
    {
        var cats = new List<string>
        {
            "British Short Hair",
            "Bengal",
            "Tabby",
            "Ragdoll",
            "Persian",
            "Siamese"
        };
        return Ok(cats);
    }
}
