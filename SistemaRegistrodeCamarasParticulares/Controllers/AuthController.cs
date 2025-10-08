using BCrypt.Net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SistemaRegistrodeCamarasParticulares.Context;
using SistemaRegistrodeCamarasParticulares.Models;
using System.Security.Claims;

namespace SistemaRegistrodeCamarasParticulares.Controllers
{
    public class AuthController : Controller
    {

        private readonly DbRegistroCamarasParticularesContext _context;

        public AuthController(DbRegistroCamarasParticularesContext context)
        {
            _context = context;
        }

        public ActionResult Login()
        {
            return View();
        }

        //Login Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string correo, string contrasena)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Correo == correo);
            if (usuario == null)
            {
                TempData["Error"] = "Correo o contraseña incorrectos.";
                return View();
            }
            bool validar = BCrypt.Net.BCrypt.Verify(contrasena, usuario.Contrasena);
            if (!validar)
            {
                TempData["Error"] = "Correo o contraseña incorrectos.";
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim("Id", usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.NombreCompleto),
                new Claim("Correo", usuario.Correo),
                new Claim(ClaimTypes.Role, usuario.Rol)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            //await new Utils.RegistroLogUtil(_context).Registro("Inicio de sesión exitoso", "Login", Request.Path, HttpContext, usuario.Correo);
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Registro()
        {
            return View();
        }

        //Registro POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro(IFormCollection form)
        {
            string contrasena = form["contrasena"];
            string confirmarContrasena = form["contrasena2"];
            if(contrasena != confirmarContrasena)
            {
                TempData["Error"] = "Las contraseñas no coinciden.";
                return View();
            }


            var usuario = new Usuario
            {
                NombreCompleto = form["nombreCompleto"],
                Telefono = form["telefono"],
                Correo = form["correo"],
                Contrasena = BCrypt.Net.BCrypt.HashPassword(contrasena),
                Municipio = form["municipio"],
                Colonia = form["colonia"],
                Codigo = null,
                Rol = "Particular",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Add(usuario);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }
    }
}
