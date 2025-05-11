using ConsultorioOPI.Repository.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOPI.Repository.Interfaces
{
    public interface IPacienteRepository
    {
        Task<IEnumerable<Paciente>> GetAllAsync();
        Task<Paciente?> GetByIdAsync(int id);
        Task<Paciente> CreateAsync(Paciente paciente);
        Task<bool> UpdateAsync(Paciente paciente);
        Task<bool> DeleteAsync(int id);
    }
}
