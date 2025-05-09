using ConsultorioOPI.Domain.Dto;
using ConsultorioOPI.Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioOPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicoService _medicoService;

        public MedicosController(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _medicoService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var medico = await _medicoService.GetByIdAsync(id);
            return medico == null ? NotFound() : Ok(medico);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MedicoDto dto)
        {
            var created = await _medicoService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MedicoDto dto)
        {
            if (id != dto.Id) return BadRequest();
            var updated = await _medicoService.UpdateAsync(dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _medicoService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }

}
