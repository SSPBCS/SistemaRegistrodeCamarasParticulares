using System;
using System.Collections.Generic;

namespace SistemaRegistrodeCamarasParticulares.Models;

public partial class Usuario
{
    public long Id { get; set; }

    public string? NombreCompleto { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Contrasena { get; set; }

    public string? Municipio { get; set; }

    public string? Colonia { get; set; }

    public string? Codigo { get; set; }

    public string? Rol { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Casa> Casas { get; set; } = new List<Casa>();

    public virtual ICollection<Documento> Documentos { get; set; } = new List<Documento>();
}
