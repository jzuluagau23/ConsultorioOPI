using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOPI.Domain.Dto
{
    public class TurnoMedicoPacienteDto
    {
        public int Id { get; set; }
        public int MedicoId { get; set; }
        public string Medico { get; set; } = null!;
        public int PacienteId { get; set; }
        public string Paciente { get; set; } = null!;
        public DateTime FechaHora { get; set; }
        public int EstadoId { get; set; }
        public string Estado { get; set; } = null!;
    }
}
