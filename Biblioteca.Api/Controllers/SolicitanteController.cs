using Biblioteca.Application.Dtos.Solicitante;
using Biblioteca.Application.Services;
using Microsoft.AspNetCore.Mvc;
namespace Biblioteca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitanteController : ControllerBase
    {
        private readonly ISolicitanteService _solicitanteService;

        public SolicitanteController(ISolicitanteService solicitanteService)
        {
            _solicitanteService = solicitanteService;
        }
        //obtener todos los Solicitantes
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var solicitantes = await _solicitanteService.GetAllAsync();
            return Ok(solicitantes);
        }
        
        //obtener solicitud por ID
        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var solicitante = await _solicitanteService.GetByIdAsync(id);
            return Ok(solicitante);
        }
        
        //obtener prestamos de un solicitante
        [HttpGet("{id}/prestamos")]
        public async Task<ActionResult> GetPrestamosBySolicitanteIdAsync(int id)
        {
            var solicitantes = await _solicitanteService.GetPrestamosBySolicitanteIdAsync(id);
            if (solicitantes == null) throw new Exception("Solicitantes not found");
            return Ok(solicitantes);
        }
        
        //obtener Registrar un nuevo solicitante
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] SolicitanteBodyDto solicitanteBody)
        {
            var solicitante = await _solicitanteService.CreateAsync(solicitanteBody);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = solicitante.Id }, solicitante);
        }
        
        //Actualizar informacion de solicitante
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] SolicitanteBodyDto solicitanteBody)
        {
            var solicitante = await _solicitanteService.UpdateAsync(id, solicitanteBody);
            return Ok(solicitante);
        }
    }
}
