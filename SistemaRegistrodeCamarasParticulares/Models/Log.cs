using System;
using System.Collections.Generic;

namespace SistemaRegistrodeCamarasParticulares.Models;

public partial class Log
{
    public Guid Id { get; set; }

    public string? Mensaje { get; set; }

    public string? Metodo { get; set; }

    public string? Ruta { get; set; }

    public string? DireccionIp { get; set; }

    public string? Usuario { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
}
