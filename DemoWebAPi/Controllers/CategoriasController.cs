using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var categorias = new List<string> { "Categoria 1", "Categoria 2", "Categoria 3" };
        return Ok(categorias);
    }
}
