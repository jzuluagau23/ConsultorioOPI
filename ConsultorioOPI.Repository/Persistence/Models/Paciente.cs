using System;
using System.Collections.Generic;

namespace ConsultorioOPI.Repository.Persistence.Models;

public partial class Paciente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Documento { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public virtual ICollection<Turno> Turnos { get; set; } = new List<Turno>();
}
