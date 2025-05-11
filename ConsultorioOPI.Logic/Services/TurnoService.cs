using AutoMapper;
using ConsultorioOPI.Domain.Dto;
using ConsultorioOPI.Domain.Entities;
using ConsultorioOPI.Logic.Interfaces;
using ConsultorioOPI.Repository.Interfaces;
using ConsultorioOPI.Repository.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOPI.Logic.Services
{
    /// <summary>
    /// Servicio de lógica de negocio para operaciones relacionadas con turnos.
    /// </summary>
    public class TurnoService : ITurnoService
    {
        private readonly ITurnoRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor del servicio TurnoService.
        /// </summary>
        /// <param name="repository">Repositorio para acceso a datos de turnos.</param>
        public TurnoService(ITurnoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<TurnoDto>> GetAllAsync()
        {
            var turnos = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TurnoDto>>(turnos);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<TurnoMedicoPacienteDto>> GetTurnosByPacienteAsync(int pacienteId)
        {
            var turnos =  await _repository.GetTurnosByPacienteAsync(pacienteId);
            return _mapper.Map<IEnumerable<TurnoMedicoPacienteDto>>(turnos);
        }
        
        /// <inheritdoc />
        public async Task<IEnumerable<TurnoMedicoPacienteDto>> GetTurnosByMedicoAsync(int medicoId)
        {
            var turnos = await _repository.GetTurnosByMedicoAsync(medicoId);
            return _mapper.Map<IEnumerable<TurnoMedicoPacienteDto>>(turnos);
        }


        /// <inheritdoc />
        public async Task<TurnoDto?> GetByIdAsync(int id)
        {
            var turno = await _repository.GetByIdAsync(id);
            return _mapper.Map<TurnoDto>(turno);
        }

        /// <inheritdoc />
        public async Task<TurnoDto> CreateAsync(TurnoDto dto)
        {
            var turno = _mapper.Map<Turno>(dto);
            var created = await _repository.CreateAsync(turno);
            dto.Id = created.Id;
            return dto;
        }

        /// <inheritdoc />
        public async Task<bool> UpdateAsync(TurnoDto dto)
        {
            var turno = _mapper.Map<Turno>(dto);
            return await _repository.UpdateAsync(turno);
        }

        /// <inheritdoc />
        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }

}
