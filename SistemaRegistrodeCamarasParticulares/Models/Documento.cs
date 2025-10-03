using System;
using System.Collections.Generic;

namespace SistemaRegistrodeCamarasParticulares.Models;

public partial class Documento
{
    public Guid Id { get; set; }

    public string? Tipo { get; set; }

    public long? IdUsuario { get; set; }

    public long? IdCasa { get; set; }

    public byte[]? Documento1 { get; set; }

    public string? Ruta { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Casa? IdCasaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
