using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SistemaRegistrodeCamarasParticulares.Context;
using SistemaRegistrodeCamarasParticulares.Models;

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
        public ActionResult Login(string correo, string contrasena)
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
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Registro()
        {
            return View();
        }

        //Registro POST
        [HttpPost]
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

    }
}
