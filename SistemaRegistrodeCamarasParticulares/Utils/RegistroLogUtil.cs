using SistemaRegistrodeCamarasParticulares.Context;
using SistemaRegistrodeCamarasParticulares.Models;

namespace SistemaRegistrodeCamarasParticulares.Utils
{
    public class RegistroLogUtil
    {
        private readonly DbRegistroCamarasParticularesContext _context;

        public RegistroLogUtil(DbRegistroCamarasParticularesContext context) 
        {
            _context = context;
        }

        public async Task Registro(string mensaje, string metodo, string path, HttpContext httpContext, string usuario)
        {
            var log = new Log
            {
                Id = Guid.NewGuid(),
                Mensaje = mensaje,
                Metodo = metodo,
                Ruta = path,
                DireccionIp = httpContext.Connection.RemoteIpAddress?.ToString(),
                Usuario = usuario,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Logs.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}
