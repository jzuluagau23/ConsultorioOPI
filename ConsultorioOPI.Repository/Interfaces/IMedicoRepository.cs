using ConsultorioOPI.Repository.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOPI.Repository.Interfaces
{
    public interface IMedicoRepository
    {
        Task<IEnumerable<Medico>> GetAllAsync();
        Task<Medico?> GetByIdAsync(int id);
        Task<Medico> CreateAsync(Medico medico);
        Task<bool> UpdateAsync(Medico medico);
        Task<bool> DeleteAsync(int id);
    }
}
