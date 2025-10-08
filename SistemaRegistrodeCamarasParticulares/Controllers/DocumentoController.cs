using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SistemaRegistrodeCamarasParticulares.Controllers
{
    public class DocumentoController : Controller
    {
        [HttpPost]
        public JsonResult Upload(IFormFile archivos)
        {
            var file = archivos;
            if (file != null && file.Length > 0)
            {
                string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + file.FileName;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/documentos", filename);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return Json(new { success = true, message = "Archivo agregado exitosamente", path = "/documentos/" + filename });
            }

            return Json(new { error = "No se seleccionó ningún archivo", status = 400 });
        }
    }
}
