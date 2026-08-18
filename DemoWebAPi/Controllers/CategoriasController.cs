using DemoWebAPi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly DataContext dataContext;

    public CategoriasController(DataContext dataContext)
    {
        this.dataContext = dataContext;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var categorias = dataContext.Categorias.ToList();
        return Ok(categorias);
    }
}
