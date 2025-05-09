using ConsultorioOPI.Domain.Dto;
using ConsultorioOPI.Repository.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOPI.Logic.Interfaces
{
    public interface IPacienteService
    {
        Task<IEnumerable<PacienteDto>> GetAllAsync();
        Task<PacienteDto?> GetByIdAsync(int id);
        Task<PacienteDto> CreateAsync(PacienteDto paciente);
        Task<bool> UpdateAsync(PacienteDto paciente);
        Task<bool> DeleteAsync(int id);
    }
}
