using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SistemaRegistrodeCamarasParticulares.Models;

namespace SistemaRegistrodeCamarasParticulares.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //[HttpPost]
        //public JsonResult recaptcha(string token)
        //{
        //    string secretKey = "6LfDtSgrAAAAAFUusogQ4XGb1PdIX-YWhF0pE2Ph";
        //    string url = $"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={token}";
        //    var response = new System.Net.WebClient().DownloadString(url);
        //    var responseKeys = System.Text.Json.JsonDocument.Parse(response).RootElement;
        //    bool success = responseKeys.GetProperty("success").GetBoolean();
        //    if(success)
        //    {
        //        return Json(new { success = true, message = "Captcha verificado con éxito." });
        //    }
        //    else
        //    {
        //        return Json(new { success = false, message = "Error al verificar el captcha." });
        //    }
        //}
    }
}
