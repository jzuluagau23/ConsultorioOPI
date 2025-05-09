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
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ConsultorioOPIContext _context;

        /// <summary>
        /// Constructor PacienteRepository
        /// </summary>
        /// <param name="context"></param>
        public PacienteRepository(ConsultorioOPIContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Paciente?> GetByIdAsync(int id) =>
            await _context.Pacientes.FindAsync(id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Paciente>> GetAllAsync() =>
            await _context.Pacientes.ToListAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns></returns>
        public async Task<Paciente> CreateAsync(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
            return paciente;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null) return false;

            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(Paciente paciente)
        {
            var existing = await _context.Pacientes.FindAsync(paciente.Id);
            if (existing == null) return false;

            existing.Nombre = paciente.Nombre;
            existing.Documento = paciente.Documento;
            existing.FechaNacimiento = paciente.FechaNacimiento;

            _context.Pacientes.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
