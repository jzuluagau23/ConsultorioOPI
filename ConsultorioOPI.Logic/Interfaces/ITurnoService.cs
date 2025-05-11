using ConsultorioOPI.Domain.Dto;
using ConsultorioOPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOPI.Logic.Interfaces
{
    public interface ITurnoService
    {
        Task<IEnumerable<TurnoDto>> GetAllAsync();
        Task<IEnumerable<TurnoMedicoPacienteDto>> GetTurnosByPacienteAsync(int pacienteId);
        Task<IEnumerable<TurnoMedicoPacienteDto>> GetTurnosByMedicoAsync(int medicoId);
        Task<TurnoDto?> GetByIdAsync(int id);
        Task<TurnoDto> CreateAsync(TurnoDto turno);
        Task<bool> UpdateAsync(TurnoDto turno);
        Task<bool> DeleteAsync(int id);
    }
}
