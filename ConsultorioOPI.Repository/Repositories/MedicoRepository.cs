using ConsultorioOPI.Repository.Interfaces;
using ConsultorioOPI.Repository.Persistence.Models;
using ConsultorioOPI.Repository.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioOPI.Repository.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ConsultorioOPIContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public MedicoRepository(ConsultorioOPIContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Medico>> GetAllAsync()
        {
            return await _context.Medicos.ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Medico?> GetByIdAsync(int id)
        {
            return await _context.Medicos.FindAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="medico"></param>
        /// <returns></returns>
        public async Task<Medico> CreateAsync(Medico medico)
        {
            _context.Medicos.Add(medico);
            await _context.SaveChangesAsync();
            return medico;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="medico"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(Medico medico)
        {
            var existing = await _context.Medicos.FindAsync(medico.Id);
            if (existing == null) return false;

            existing.Nombre = medico.Nombre;
            existing.Especialidad = medico.Especialidad;
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var medico = await _context.Medicos.FindAsync(id);
            if (medico == null) return false;

            _context.Medicos.Remove(medico);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
