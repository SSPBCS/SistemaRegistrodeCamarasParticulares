using System;
using System.Collections.Generic;

namespace SistemaRegistrodeCamarasParticulares.Models;

public partial class Camara
{
    public long Id { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public string? TipoCamara { get; set; }

    public string? TipoUbicacion { get; set; }

    public string? DescripcionUbicacion { get; set; }

    public string? TipoUsoCamara { get; set; }

    public bool? Validacion { get; set; }

    public string? ObservacionValidacion { get; set; }

    public DateTime? FechaFabricacion { get; set; }

    public long? IdCasa { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Casa? IdCasaNavigation { get; set; }
}
