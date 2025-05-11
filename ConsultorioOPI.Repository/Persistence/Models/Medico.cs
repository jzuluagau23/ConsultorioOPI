using System;
using System.Collections.Generic;

namespace ConsultorioOPI.Repository.Persistence.Models;

public partial class Medico
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Especialidad { get; set; } = null!;

    public virtual ICollection<Turno> Turnos { get; set; } = new List<Turno>();
}
