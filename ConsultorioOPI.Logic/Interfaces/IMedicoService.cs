using ConsultorioOPI.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOPI.Logic.Interfaces
{
    public interface IMedicoService
    {
        Task<IEnumerable<MedicoDto>> GetAllAsync();
        Task<MedicoDto?> GetByIdAsync(int id);
        Task<MedicoDto> CreateAsync(MedicoDto medico);
        Task<bool> UpdateAsync(MedicoDto medico);
        Task<bool> DeleteAsync(int id);
    }
}
