using ConsultorioOPI.Domain.Entities;
using ConsultorioOPI.Repository.Interfaces;
using ConsultorioOPI.Repository.Persistence;
using ConsultorioOPI.Repository.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioOPI.Repository.Repositories
{
    /// <summary>
    /// Repositorio para operaciones CRUD de la entidad Turno.
    /// </summary>
    public class TurnoRepository : ITurnoRepository
    {
        private readonly ConsultorioOPIContext _context;

        /// <summary>
        /// Constructor del repositorio TurnoRepository.
        /// </summary>
        /// <param name="context">Contexto de base de datos.</param>
        public TurnoRepository(ConsultorioOPIContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todos los turnos registrados en la base de datos.
        /// </summary>
        /// <returns>Lista de turnos.</returns>
        public async Task<IEnumerable<Turno>> GetAllAsync()
        {
            return await _context.Turnos.ToListAsync();
        }

        /// <summary>
        /// Obtiene todos los turnos registrados en la base de datos de un medico.
        /// </summary>
        /// <param name="medicoId">Identificador del medico</param>
        /// <returns>Lista de turnos.</returns>
        public async Task<IEnumerable<TurnoMedicoPacienteEntity>> GetTurnosByMedicoAsync(int medicoId)
        {
            return await _context.Turnos
             .Where(t => t.MedicoId == medicoId)
             .Include(t => t.Medico)
             .Include(t => t.Paciente)
             .Include(t => t.Estado)
             .Select(t => new TurnoMedicoPacienteEntity
             {
                 Id = t.Id,
                 MedicoId = t.MedicoId,
                 Medico = t.Medico.Nombre,
                 PacienteId = t.PacienteId,
                 Paciente = t.Paciente.Nombre,
                 FechaHora = t.FechaHora,
                 EstadoId = t.EstadoId,
                 Estado = t.Estado.Nombre
             })
             .ToListAsync();
        }
        /// <summary>
        ///  Obtiene todos los turnos registrados en la base de datos de un
        /// </summary>
        /// <param name="pacienteId">Identificador del paciente</param>
        /// <returns>Lista de turnos.</returns>
        public async Task<IEnumerable<TurnoMedicoPacienteEntity>> GetTurnosByPacienteAsync(int pacienteId) 
        {
            return await _context.Turnos
            .Where(t => t.PacienteId == pacienteId)
            .Include(t => t.Medico)
            .Include(t => t.Paciente)
            .Include(t => t.Estado)
            .Select(t => new TurnoMedicoPacienteEntity
            {
                Id = t.Id,
                MedicoId = t.MedicoId,
                Medico = t.Medico.Nombre,
                PacienteId = t.PacienteId,
                Paciente = t.Paciente.Nombre,
                FechaHora = t.FechaHora,
                EstadoId = t.EstadoId,
                Estado = t.Estado.Nombre
            })
            .ToListAsync();
        }

        /// <summary>
        /// Obtiene un turno por su identificador.
        /// </summary>
        /// <param name="id">Identificador del turno.</param>
        /// <returns>Turno encontrado o null si no existe.</returns>
        public async Task<Turno?> GetByIdAsync(int id)
        {
            return await _context.Turnos.FindAsync(id);
        }

        /// <summary>
        /// Crea un nuevo turno en la base de datos.
        /// </summary>
        /// <param name="turno">Turno a crear.</param>
        /// <returns>Turno creado con su ID asignado.</returns>
        public async Task<Turno> CreateAsync(Turno turno)
        {
            _context.Turnos.Add(turno);
            await _context.SaveChangesAsync();
            return turno;
        }

        /// <summary>
        /// Actualiza un turno existente.
        /// </summary>
        /// <param name="turno">Turno con la información actualizada.</param>
        /// <returns>True si se actualizó, false si no se encontró.</returns>
        public async Task<bool> UpdateAsync(Turno turno)
        {
            var existing = await _context.Turnos.FindAsync(turno.Id);
            if (existing == null) return false;

            existing.FechaHora = turno.FechaHora;
            existing.MedicoId = turno.MedicoId;
            existing.PacienteId = turno.PacienteId;
            existing.EstadoId = turno.EstadoId;

            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Elimina un turno por su ID.
        /// </summary>
        /// <param name="id">Identificador del turno.</param>
        /// <returns>True si se eliminó, false si no se encontró.</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var turno = await _context.Turnos.FindAsync(id);
            if (turno == null) return false;

            _context.Turnos.Remove(turno);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
