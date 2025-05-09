using ConsultorioOPI.Domain.Entities;
using ConsultorioOPI.Repository.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOPI.Repository.Interfaces
{
    public interface ITurnoRepository
    {
        Task<IEnumerable<Turno>> GetAllAsync();
        Task<IEnumerable<TurnoMedicoPacienteEntity>> GetTurnosByPacienteAsync(int pacienteId);
        Task<IEnumerable<TurnoMedicoPacienteEntity>> GetTurnosByMedicoAsync(int medicoId);
        Task<Turno?> GetByIdAsync(int id);
        Task<Turno> CreateAsync(Turno turno);
        Task<bool> UpdateAsync(Turno turno);
        Task<bool> DeleteAsync(int id);
    }
}
