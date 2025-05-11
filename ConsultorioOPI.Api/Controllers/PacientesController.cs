using ConsultorioOPI.Domain.Dto;
using ConsultorioOPI.Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioOPI.Api.Controllers
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con los pacientes.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _service;

        /// <summary>
        /// Constructor del controlador PacientesController.
        /// </summary>
        /// <param name="service">Servicio de lógica de negocio para pacientes.</param>
        public PacientesController(IPacienteService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtiene un paciente por su identificador.
        /// </summary>
        /// <param name="id">Identificador del paciente.</param>
        /// <returns>Retorna el paciente si existe, de lo contrario NotFound.</returns>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            var paciente = await _service.GetByIdAsync(id);
            if (paciente == null) return NotFound();
            return Ok(paciente);
        }

        /// <summary>
        /// Obtiene todos los pacientes registrados.
        /// </summary>
        /// <returns>Lista de pacientes.</returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        /// <summary>
        /// Crea un nuevo paciente.
        /// </summary>
        /// <param name="paciente">Datos del paciente a crear.</param>
        /// <returns>Paciente creado con su identificador.</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(PacienteDto paciente)
        {
            var created = await _service.CreateAsync(paciente);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        /// <summary>
        /// Actualiza un paciente existente.
        /// </summary>
        /// <param name="id">Identificador del paciente a actualizar.</param>
        /// <param name="paciente">Datos actualizados del paciente.</param>
        /// <returns>Resultado de la operación de actualización.</returns>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, PacienteDto paciente)
        {
            if (id != paciente.Id) return BadRequest();
            var updated = await _service.UpdateAsync(paciente);
            return Ok(updated);
        }

        /// <summary>
        /// Elimina un paciente por su identificador.
        /// </summary>
        /// <param name="id">Identificador del paciente a eliminar.</param>
        /// <returns>NoContent si se eliminó correctamente, NotFound si no existe.</returns>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
