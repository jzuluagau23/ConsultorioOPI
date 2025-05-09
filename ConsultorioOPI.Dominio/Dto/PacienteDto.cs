using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioOPI.Domain.Dto
{
    public class PacienteDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Documento { get; set; } = null!;

        public DateOnly FechaNacimiento { get; set; }
    }
}
