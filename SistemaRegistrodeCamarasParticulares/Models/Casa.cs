using System;
using System.Collections.Generic;

namespace SistemaRegistrodeCamarasParticulares.Models;

public partial class Casa
{
    public long Id { get; set; }

    public long? IdUsuario { get; set; }

    public string? TipoCasa { get; set; }

    public string? Descripcion { get; set; }

    public string? Municipio { get; set; }

    public string? Colonia { get; set; }

    public string? CallePrincipal { get; set; }

    public string? CalleSecundaria { get; set; }

    public string? CalleTercera { get; set; }

    public string? CodigoPostal { get; set; }

    public string? NumeroExterior { get; set; }

    public string? NumeroInterior { get; set; }

    public int? NumCamsFijas { get; set; }

    public int? NumCamsMoviles { get; set; }

    public string? Componentes { get; set; }

    public string? TiempoGrabacion { get; set; }

    public string? Latitud { get; set; }

    public string? Longitud { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Camara> Camaras { get; set; } = new List<Camara>();

    public virtual ICollection<Documento> Documentos { get; set; } = new List<Documento>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
