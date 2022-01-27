using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel_Pandiani.Models;

namespace Hotel_Pandiani.Controllers
{
    public class AsistenciasController : Controller
    {
        private readonly HotelContext _context;

        public AsistenciasController(HotelContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var hotelContext = _context.Asistencia.Include(a => a.Empleado);

            return View(await hotelContext.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistencia = await _context.Asistencia
                .Include(a => a.Empleado)
                .FirstOrDefaultAsync(m => m.AsistenciaId == id);

            if (asistencia == null)
            {
                return NotFound();
            }

            return View(asistencia);
        }

        
        public IActionResult Create()
        {
            var asistencia = new List<AsistenciaEnum>();

            foreach (AsistenciaEnum a in Enum.GetValues(typeof(AsistenciaEnum)))
            {
                asistencia.Add(a);
            }
            ViewData["as"] = asistencia;

            ViewBag.Empleados = _context.Empleados.Select(x => new SelectListItem
            {
                Text = x.Nombre,
                Value = x.Id.ToString()
            }).ToList();

            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido");

            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AsistenciaId,EmpleadoId,Estado,Dia")] Asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asistencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido", asistencia.EmpleadoId);
            return View(asistencia);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistencia = await _context.Asistencia.FindAsync(id);
            if (asistencia == null)
            {
                return NotFound();
            }
            ViewBag.Empleaditos = _context.Empleados.ToList();
            ViewData["ListaEnums"] = ObtenerEnums();
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido", asistencia.EmpleadoId);
            return View(asistencia);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AsistenciaId,EmpleadoId,Estado,Dia")] Asistencia asistencia)
        {
            if (id != asistencia.AsistenciaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asistencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsistenciaExists(asistencia.AsistenciaId))
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido", asistencia.EmpleadoId);
            return View(asistencia);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistencia = await _context.Asistencia
                .Include(a => a.Empleado)
                .FirstOrDefaultAsync(m => m.AsistenciaId == id);
            if (asistencia == null)
            {
                return NotFound();
            }

            return View(asistencia);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asistencia = await _context.Asistencia.FindAsync(id);
            _context.Asistencia.Remove(asistencia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsistenciaExists(int id)
        {
            return _context.Asistencia.Any(e => e.AsistenciaId == id);
        }
        public List<AsistenciaEnum> ObtenerEnums()
        {

            var Asistencia = new List<AsistenciaEnum>();

            foreach (AsistenciaEnum a in Enum.GetValues(typeof(AsistenciaEnum)))
            {

                Asistencia.Add(a);
            }
            return Asistencia;
        }
    }
}
