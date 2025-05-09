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
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _repository;
        private readonly  IMapper _mapper;

        public MedicoService(IMedicoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MedicoDto>> GetAllAsync()
        {
            var medicos = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<MedicoDto>>(medicos);
        }

        public async Task<MedicoDto?> GetByIdAsync(int id)
        {
            var medico = await _repository.GetByIdAsync(id);
            return _mapper.Map<MedicoDto>(medico);
        }

        public async Task<MedicoDto> CreateAsync(MedicoDto dto)
        {
            var medico = _mapper.Map<Medico>(dto);
            var created = await _repository.CreateAsync(medico);
            dto.Id = created.Id;
            return dto;
        }

        public async Task<bool> UpdateAsync(MedicoDto dto)
        {
            var medico = _mapper.Map<Medico>(dto);
            return await _repository.UpdateAsync(medico);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
