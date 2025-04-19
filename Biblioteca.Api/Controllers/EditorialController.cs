using Biblioteca.Application.Dtos.Editorial;
using Biblioteca.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialController : ControllerBase
    {
        private readonly IEditorialService _editorialService;
        
        public EditorialController(IEditorialService editorialService)
        {
            _editorialService = editorialService;
        }
        //obtener todas las editoriales
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var editoriales = await _editorialService.GetAllAsync();
            return Ok(editoriales);
        }
        //obeter una editorial por Id
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var editorial = await _editorialService.GetByIdAsync(id);
            if (editorial == null)
            {
                return NotFound();
            }

            return Ok(editorial);
        }
        //obtener libros por una editorial
        [HttpGet("{id}/libros")]
        public async Task<ActionResult> GetLibros(int id)
        {
            try
            {
                var result = await _editorialService.GetLibrosByEditorialAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
        //crear una editorial
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] EditorialBodyDto dto)
        {
            var result = await _editorialService.CreateAsync(dto);


            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        //actualizar una editorial
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] EditorialBodyDto bodyDto)
        {
            var result = await _editorialService.UpdateAsync(id, bodyDto);
            return Ok(result);
        }
        //borrar una editorial
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _editorialService.DeleteAsync(id);
            return NoContent();
        }
    }
}