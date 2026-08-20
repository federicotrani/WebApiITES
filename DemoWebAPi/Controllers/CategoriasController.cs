using DemoWebAPi.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoWebAPi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly DataContext _context;

    public CategoriasController(DataContext dataContext)
    {
        _context = dataContext;
    }

    [HttpGet]
    public IActionResult GetCategorias()
    {
        var categorias = _context.Categorias.ToList();
        return Ok(categorias);
    }

    [HttpPost]
    public IActionResult CreateCategoria([FromBody] Models.Categoria categoria)
    {
        if (categoria == null)
        {
            return BadRequest(new { message = "Categorias es nulo" });
        }
        try
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCategorias), new { id = categoria.Id }, categoria);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error creando categoria", error = ex.Message });
        }
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateCategoria(int id, [FromBody] Models.Categoria categoria)
    {
        if (categoria == null)
        {
            return BadRequest(new { message = "Categorias es nulo" });
        }
        try
        {
            var categoriaExistente = _context.Categorias.Find(id);
            if (categoriaExistente == null)
            {
                return NotFound(new { message = "Categoria no encontrada" });
            }
            categoriaExistente.Nombre = categoria.Nombre;
            _context.SaveChanges();
            return Ok(categoriaExistente);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error actualizando categoria", error = ex.Message });
        }
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteCategoria(int id)
    {
        try
        {
            var categoriaExistente = _context.Categorias.Find(id);
            if (categoriaExistente == null)
            {
                return NotFound(new { message = "Categoria no encontrada" });
            }
            _context.Categorias.Remove(categoriaExistente);
            _context.SaveChanges();
            return Ok(new { message = "Categoria eliminada correctamente" });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error eliminando categoria", error = ex.Message });
        }
    }

    [HttpGet("{id:int}")]
    public IActionResult GetCategoria(int id)
    {
        try
        {
            var categoria = _context.Categorias.Find(id);
            if (categoria == null)
            {
                return NotFound(new { message = "Categoria no encontrada" });
            }
            return Ok(categoria);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error recuperando categoria", error = ex.Message });
        }
    }
}
