using ConsultorioOPI.Domain.Dto;
using ConsultorioOPI.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioOPI.Api.Controllers
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con los turnos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TurnosController : ControllerBase
    {
        private readonly ITurnoService _service;

        /// <summary>
        /// Constructor del controlador TurnosController.
        /// </summary>
        /// <param name="service">Servicio de lógica de negocio para turnos.</param>
        public TurnosController(ITurnoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtiene un turno por su identificador.
        /// </summary>
        /// <param name="id">Identificador del turno.</param>
        /// <returns>Retorna el turno si existe, de lo contrario NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var turno = await _service.GetByIdAsync(id);
            if (turno == null) return NotFound();
            return Ok(turno);
        }

        /// <summary>
        /// Obtiene todos los turnos registrados.
        /// </summary>
        /// <returns>Lista de turnos.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());
        /// <summary>
        /// Obtiene todos los turnos registrados a un medico
        /// </summary>
        /// <param name="pacienteId"></param>
        /// <returns>Lista de turnos.</returns>
        [HttpGet("por-paciente/{pacienteId}")]
        public async Task<IActionResult> GetTurnosByPaciente(int pacienteId)
        {
            var result = await _service.GetTurnosByPacienteAsync(pacienteId);
            return Ok(result);
        }

        /// <summary>
        /// Obtiene todos los turnos de un paciente
        /// </summary>
        /// <param name="medicoId"></param>
        /// <returns>Lista de turnos.</returns>
        [HttpGet("por-medico/{medicoId}")]
        public async Task<IActionResult> GetTurnosByMedico(int medicoId)
        {
            var result = await _service.GetTurnosByMedicoAsync(medicoId);
            return Ok(result);
        }


        /// <summary>
        /// Crea un nuevo turno.
        /// </summary>
        /// <param name="turno">Datos del turno a crear.</param>
        /// <returns>Turno creado con su identificador.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(TurnoDto turno)
        {
            var created = await _service.CreateAsync(turno);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        /// <summary>
        /// Actualiza un turno existente.
        /// </summary>
        /// <param name="id">Identificador del turno a actualizar.</param>
        /// <param name="turno">Datos actualizados del turno.</param>
        /// <returns>Resultado de la operación de actualización.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TurnoDto turno)
        {
            if (id != turno.Id) return BadRequest();
            var updated = await _service.UpdateAsync(turno);
            return Ok(updated);
        }

        /// <summary>
        /// Elimina un turno por su identificador.
        /// </summary>
        /// <param name="id">Identificador del turno a eliminar.</param>
        /// <returns>NoContent si se eliminó correctamente, NotFound si no existe.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
