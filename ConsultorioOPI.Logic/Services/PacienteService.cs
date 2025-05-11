using AutoMapper;
using ConsultorioOPI.Domain.Dto;
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
    /// Servicio de lógica de negocio para operaciones relacionadas con pacientes.
    /// </summary>
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor del servicio PacienteService.
        /// </summary>
        /// <param name="repository">Repositorio para acceso a datos de pacientes.</param>
        public PacienteService(IPacienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<PacienteDto>> GetAllAsync()
        {
            var pacientes = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PacienteDto>>(pacientes);
        }

        /// <inheritdoc />
        public async Task<PacienteDto?> GetByIdAsync(int id)
        {
            var paciente = await _repository.GetByIdAsync(id);
            return _mapper.Map<PacienteDto>(paciente);
        }

        /// <inheritdoc />
        public async Task<PacienteDto> CreateAsync(PacienteDto dto)
        {
            var paciente = _mapper.Map<Paciente>(dto);
            var created = await _repository.CreateAsync(paciente);
            dto.Id = created.Id;
            return dto;
        }

        /// <inheritdoc />
        public async Task<bool> UpdateAsync(PacienteDto dto)
        {
            var paciente = _mapper.Map<Paciente>(dto);
            return await _repository.UpdateAsync(paciente);
        }

        /// <inheritdoc />
        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
