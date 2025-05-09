using System;
using System.Collections.Generic;

namespace ConsultorioOPI.Repository.Persistence.Models;

public partial class Turno
{
    public int Id { get; set; }

    public int MedicoId { get; set; }

    public int PacienteId { get; set; }

    public DateTime FechaHora { get; set; }

    public int EstadoId { get; set; }

    public virtual EstadosTurno Estado { get; set; } = null!;

    public virtual Medico Medico { get; set; } = null!;

    public virtual Paciente Paciente { get; set; } = null!;
}
