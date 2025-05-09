using System;
using System.Collections.Generic;

namespace ConsultorioOPI.Repository.Persistence.Models;

public partial class EstadosTurno
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Turno> Turnos { get; set; } = new List<Turno>();
}
