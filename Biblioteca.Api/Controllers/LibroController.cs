using Biblioteca.Application.Dtos.Libro;
using Biblioteca.Application.Services;
using Microsoft.AspNetCore.Mvc;
namespace Biblioteca.Api.Properties
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;

        public LibroController(ILibroService libroService)
        {
            _libroService = libroService;
        }
        // Obtener todos los libros
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var libros = await _libroService.GetAllAsync();
            return Ok(libros);
        }
        
        //obtener libro por ID
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var libro = await _libroService.GetByIdAsync(id);
            return Ok(libro);
        }
        
        //agrear nuevo libro
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] LibroBodyDto libroBody)
        {
            var libro = await _libroService.CreateAsync(libroBody);
            return CreatedAtAction(nameof(GetById), new { id = libro.Id }, libro);
        }
        
        //actualizar libro
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] LibroBodyDto libroBody)
        {
            var libro = await _libroService.UpdateAsync(id, libroBody);
            return Ok(libro);
        }
        
        //Eliminar libro
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _libroService.DeleteAsync(id);
            return NoContent();
        }
        
        //obetener libros disponibles
        [HttpGet("disponibles")]
        public async Task<ActionResult> GetLibrosDisponibles()
        {
            var libros = await _libroService.GetLibrosDisponiblesAsync();
            return Ok(libros);
        }
        
        //obtener libro por autor
        [HttpGet("autor/{nombre}")]
        public async Task<ActionResult> GetLibrosByAutor(string nombre)
        {
            var libros = await _libroService.GetLibrosByAutorAsync(nombre);
            if (libros == null || !libros.Any()) throw new Exception("No libros found");
            return Ok(libros);
        }
    }
}
