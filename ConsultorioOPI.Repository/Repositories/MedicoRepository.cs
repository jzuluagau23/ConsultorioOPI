using ConsultorioOPI.Repository.Interfaces;
using ConsultorioOPI.Repository.Persistence;
using ConsultorioOPI.Repository.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioOPI.Repository.Repositories
{
    /// <summary>
    /// Repositorio para operaciones CRUD de la entidad Medico.
    /// </summary>
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ConsultorioOPIContext _context;

        /// <summary>
        /// Constructor del repositorio MedicoRepository.
        /// </summary>
        /// <param name="context">Contexto de base de datos.</param>
        public MedicoRepository(ConsultorioOPIContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todos los médicos registrados.
        /// </summary>
        /// <returns>Lista de médicos.</returns>
        public async Task<IEnumerable<Medico>> GetAllAsync()
        {
            return await _context.Medicos.ToListAsync();
        }

        /// <summary>
        /// Obtiene un médico por su identificador.
        /// </summary>
        /// <param name="id">ID del médico.</param>
        /// <returns>Médico encontrado o null si no existe.</returns>
        public async Task<Medico?> GetByIdAsync(int id)
        {
            return await _context.Medicos.FindAsync(id);
        }

        /// <summary>
        /// Crea un nuevo médico.
        /// </summary>
        /// <param name="medico">Médico a crear.</param>
        /// <returns>Médico creado con su ID asignado.</returns>
        public async Task<Medico> CreateAsync(Medico medico)
        {
            _context.Medicos.Add(medico);
            await _context.SaveChangesAsync();
            return medico;
        }

        /// <summary>
        /// Actualiza un médico existente.
        /// </summary>
        /// <param name="medico">Médico con la información actualizada.</param>
        /// <returns>True si se actualizó, false si no se encontró.</returns>
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
        /// Elimina un médico por su ID.
        /// </summary>
        /// <param name="id">Identificador del médico.</param>
        /// <returns>True si se eliminó, false si no se encontró.</returns>
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
