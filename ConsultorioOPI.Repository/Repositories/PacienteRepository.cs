using ConsultorioOPI.Repository.Interfaces;
using ConsultorioOPI.Repository.Persistence;
using ConsultorioOPI.Repository.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioOPI.Repository.Repositories
{
    /// <summary>
    /// Repositorio para operaciones CRUD de la entidad Paciente.
    /// </summary>
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ConsultorioOPIContext _context;

        /// <summary>
        /// Constructor del repositorio PacienteRepository.
        /// </summary>
        /// <param name="context">Contexto de base de datos.</param>
        public PacienteRepository(ConsultorioOPIContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todos los pacientes registrados.
        /// </summary>
        /// <returns>Lista de pacientes.</returns>
        public async Task<IEnumerable<Paciente>> GetAllAsync()
        {
            return await _context.Pacientes.ToListAsync();
        }

        /// <summary>
        /// Obtiene un paciente por su identificador.
        /// </summary>
        /// <param name="id">ID del paciente.</param>
        /// <returns>Paciente encontrado o null si no existe.</returns>
        public async Task<Paciente?> GetByIdAsync(int id)
        {
            return await _context.Pacientes.FindAsync(id);
        }

        /// <summary>
        /// Crea un nuevo paciente.
        /// </summary>
        /// <param name="paciente">Paciente a crear.</param>
        /// <returns>Paciente creado con su ID asignado.</returns>
        public async Task<Paciente> CreateAsync(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
            return paciente;
        }

        /// <summary>
        /// Actualiza un paciente existente.
        /// </summary>
        /// <param name="paciente">Paciente con la información actualizada.</param>
        /// <returns>True si se actualizó, false si no se encontró.</returns>
        public async Task<bool> UpdateAsync(Paciente paciente)
        {
            var existing = await _context.Pacientes.FindAsync(paciente.Id);
            if (existing == null) return false;

            existing.Nombre = paciente.Nombre;
            existing.Documento = paciente.Documento;
            existing.FechaNacimiento = paciente.FechaNacimiento;

            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Elimina un paciente por su ID.
        /// </summary>
        /// <param name="id">Identificador del paciente.</param>
        /// <returns>True si se eliminó, false si no se encontró.</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null) return false;

            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
