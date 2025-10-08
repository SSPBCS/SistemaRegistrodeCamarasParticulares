using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaRegistrodeCamarasParticulares.Context;
using SistemaRegistrodeCamarasParticulares.Models;
using System.IO;

namespace SistemaRegistrodeCamarasParticulares.Controllers
{
    [Authorize(Roles = "Particular")]
    public class CasaController : Controller
    {
        private readonly DbRegistroCamarasParticularesContext _context;

        public CasaController(DbRegistroCamarasParticularesContext context)
        {
            _context = context;
        }

        // GET: Casa
        public async Task<IActionResult> Index()
        {
            var dbRegistroCamarasParticularesContext = _context.Casas.Include(c => c.IdUsuarioNavigation);
            return View(await dbRegistroCamarasParticularesContext.ToListAsync());
        }

        // GET: Casa/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casa = await _context.Casas
                .Include(c => c.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (casa == null)
            {
                return NotFound();
            }

            return View(casa);
        }

        // GET: Casa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Casa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection coleccion, [Bind("Id,IdUsuario,TipoCasa,Descripcion,Municipio,Colonia,CallePrincipal,CalleSecundaria,CalleTercera," +
            "CodigoPostal,NumeroExterior,NumeroInterior,NumCamsFijas,NumCamsMoviles,Componentes,TiempoGrabacion,Latitud,Longitud")] Casa casa)
        {
            if (ModelState.IsValid)
            {
                string path = coleccion["archivos"];
                if (string.IsNullOrEmpty(path))
                {
                    TempData["Error"] = "Debe cargar el comprobante de domicilio de la casa.";
                    return View(casa);
                }

                casa.CreatedAt = DateTime.Now;
                casa.UpdatedAt = DateTime.Now;
                _context.Add(casa);
                await _context.SaveChangesAsync();


                //obtener documento de la carpeta documentos
                string contenido = System.IO.File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", path.TrimStart('/')));
                byte[] documentoBytes = System.Text.Encoding.UTF8.GetBytes(contenido);


                var documento = new Documento
                {
                    Id = Guid.NewGuid(),
                    Tipo = "Domicilio",
                    IdUsuario = casa.IdUsuario,
                    IdCasa = casa.Id,
                    Documento1 = documentoBytes,
                    Ruta = path,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                
                _context.Add(documento);

                //borrar archivo de la carpeta documentos
                System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", path.TrimStart('/')));

                await _context.SaveChangesAsync();
                TempData["Success"] = "Casa registrada correctamente.";
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", casa.IdUsuario);
            TempData["Error"] = "Error al registrar la Casa, verifique la información e intentelo de nuevo";
            return View(casa);
        }

        // GET: Casa/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casa = await _context.Casas.FindAsync(id);
            if (casa == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", casa.IdUsuario);
            return View(casa);
        }

        // POST: Casa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,IdUsuario,Descripcion,Municipio,Colonia,CallePrincipal,CalleSecundaria,CalleTercera,CodigoPostal,NumeroExterior,NumeroInterior,Latitud,Longitud,CreatedAt,UpdatedAt,DeletedAt")] Casa casa)
        {
            if (id != casa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(casa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CasaExists(casa.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", casa.IdUsuario);
            return View(casa);
        }

        // GET: Casa/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casa = await _context.Casas
                .Include(c => c.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (casa == null)
            {
                return NotFound();
            }

            return View(casa);
        }

        // POST: Casa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var casa = await _context.Casas.FindAsync(id);
            if (casa != null)
            {
                _context.Casas.Remove(casa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CasaExists(long id)
        {
            return _context.Casas.Any(e => e.Id == id);
        }
    }
}
