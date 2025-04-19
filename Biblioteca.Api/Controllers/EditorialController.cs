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
        private readonly ILogger<EditorialController> _logger;
        public EditorialController(IEditorialService editorialService, ILogger<EditorialController> logger)
        {
            _editorialService = editorialService;
            _logger = logger;
        }
        //Getting all editorials
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {   
            _logger.LogInformation("Getting all editorials");
            var editoriales = await _editorialService.GetAllAsync();
            if (editoriales == null || !editoriales.Any())
            {
                _logger.LogWarning("No editorials found."); // Log de advertencia
                return NotFound("No editorials found.");
            }

            return Ok(editoriales);
        }
        //Getting editorial by Id
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            _logger.LogInformation("Getting editorial by Id: {Id}", id);
            var editorial = await _editorialService.GetByIdAsync(id);
            if (editorial == null)
            {
                _logger.LogWarning("Editorial with Id: {Id} not found", id); // Log de advertencia
                return NotFound();
            }

            return Ok(editorial);
        }
        //Getting books for editorial Id
        [HttpGet("{id}/libros")]
        public async Task<ActionResult> GetLibros(int id)
        {
            _logger.LogInformation("Getting books for editorial Id: {Id}", id);
            try
            {
                var result = await _editorialService.GetLibrosByEditorialAsync(id);
                if (result == null || !result.Any())
                {
                    _logger.LogWarning("No books found for editorial Id: {Id}", id);
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError("Error occurred while getting books for editorial Id: {Id}. Exception: {ExceptionMessage}", id, e.Message);// Log de error
                return StatusCode(500, "An error occurred while fetching the books.");
            }
        }
        //Creating new editorial
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] EditorialBodyDto dto)
        {
            _logger.LogInformation("Creating new editorial");

            try
            {
                var result = await _editorialService.CreateAsync(dto);
                _logger.LogInformation("Editorial created successfully");

                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (Exception e)
            {
                _logger.LogError("Error occurred while creating a new editorial. Exception: {ExceptionMessage}", e.Message); // Log de error
                return StatusCode(500, "An error occurred while creating the editorial.");
            }
        }
        //pdating editorial with Id
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] EditorialBodyDto bodyDto)
        {
            _logger.LogInformation("Updating editorial with Id: {Id}", id);

            try
            {
                var result = await _editorialService.UpdateAsync(id, bodyDto);
                if (result == null)
                {
                    _logger.LogWarning("Editorial with Id: {Id} not found for update", id); // Log de advertencia
                    return NotFound();
                }

                _logger.LogInformation("Editorial with Id: {Id} updated successfully", id); // Log de éxito
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError("Error occurred while updating editorial with Id: {Id}. Exception: {ExceptionMessage}", id, e.Message); // Log de error
                return StatusCode(500, "An error occurred while updating the editorial.");
            }
        }
        //Deleting editorial with Id
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            _logger.LogInformation("Deleting editorial with Id: {Id}", id);

            try
            {
                await _editorialService.DeleteAsync(id);
                _logger.LogInformation("Editorial with Id: {Id} deleted successfully", id); // Log de éxito
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError("Error occurred while deleting editorial with Id: {Id}. Exception: {ExceptionMessage}", id, e.Message); // Log de error
                return StatusCode(500, "An error occurred while deleting the editorial.");
            }
        }
    }
}