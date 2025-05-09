using ConsultorioOPI.Domain.Dto;
using ConsultorioOPI.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioOPI.Api.Controllers
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con los médicos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicoService _service;

        /// <summary>
        /// Constructor del controlador MedicosController.
        /// </summary>
        /// <param name="service">Servicio de lógica de negocio para médicos.</param>
        public MedicosController(IMedicoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtiene un médico por su identificador.
        /// </summary>
        /// <param name="id">Identificador del médico.</param>
        /// <returns>Retorna el médico si existe, de lo contrario NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var medico = await _service.GetByIdAsync(id);
            if (medico == null) return NotFound();
            return Ok(medico);
        }

        /// <summary>
        /// Obtiene todos los médicos registrados.
        /// </summary>
        /// <returns>Lista de médicos.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        /// <summary>
        /// Crea un nuevo médico.
        /// </summary>
        /// <param name="medico">Datos del médico a crear.</param>
        /// <returns>Médico creado con su identificador.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(MedicoDto medico)
        {
            var created = await _service.CreateAsync(medico);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        /// <summary>
        /// Actualiza un médico existente.
        /// </summary>
        /// <param name="id">Identificador del médico a actualizar.</param>
        /// <param name="medico">Datos actualizados del médico.</param>
        /// <returns>Resultado de la operación de actualización.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MedicoDto medico)
        {
            if (id != medico.Id) return BadRequest();
            var updated = await _service.UpdateAsync(medico);
            return Ok(updated);
        }

        /// <summary>
        /// Elimina un médico por su identificador.
        /// </summary>
        /// <param name="id">Identificador del médico a eliminar.</param>
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
