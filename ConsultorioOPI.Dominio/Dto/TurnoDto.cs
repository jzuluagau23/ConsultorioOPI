using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOPI.Domain.Dto
{
    public class TurnoDto
    {
        public int Id { get; set; }

        public int MedicoId { get; set; }

        public int PacienteId { get; set; }

        public DateTime FechaHora { get; set; }

        public int EstadoId { get; set; }
    }
}
