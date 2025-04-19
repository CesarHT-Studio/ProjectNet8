using Biblioteca.Application.Dtos.Prestamo;
using Biblioteca.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly IPrestamoService _prestamoService;

        public PrestamoController(IPrestamoService prestamoService)
        {
            _prestamoService = prestamoService;
        }
        
        // Obtener todos los préstamos
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var prestamos = await _prestamoService.GetAllAsync();
            return Ok(prestamos);
        }
        //Obtener préstamo por ID
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var prestamo = await _prestamoService.GetByIdAsync(id);
            return Ok(prestamo);
        }
        // Obtener préstamos activos
        [HttpGet("activos")]
        public async Task<ActionResult> GetActivosAsync()
        {
            var prestamos = await _prestamoService.GetPrestamosActivosAsync();
            return Ok(prestamos);
        }
        //Obtener préstamos vencidos
        [HttpGet("vencidos")]
        public async Task<ActionResult> GetVencidosAsync()
        {
            var prestamos = await _prestamoService.GetPrestamosVencidosAsync();
            return Ok(prestamos);
        }
        // Registrar un nuevo préstamo
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PrestamoBodyDto prestamoBody)
        {
            var prestamo = await _prestamoService.CreateAsync(prestamoBody);
            return CreatedAtAction(nameof(GetById), new { id = prestamo.Id }, prestamo);
        }
        //Registrar devolución de un libro
        [HttpPut("{id}/devolver")]
        public async Task<IActionResult> MarcarComoDevuelto(int id)
        {
            var result = await _prestamoService.MarcarComoDevueltoAsync(id);
            return result ? Ok() : NotFound();
        }
        //Extender fecha de devolución
        [HttpPut("{id}/extender")]
        public async Task<IActionResult> Extender(int id, [FromBody] DateTime nuevaFecha)
        {
            var result = await _prestamoService.ExtenderFechaDevolucionAsync(id, nuevaFecha);
            return result ? Ok() : NotFound();
        }
    }
}
