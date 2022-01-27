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
    public class TelefonosController : Controller
    {
        private readonly HotelContext _context;

        public TelefonosController(HotelContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var hotelContext = _context.Telefonos.Include(t => t.Empleado);
            return View(await hotelContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await _context.Telefonos
                .Include(t => t.Empleado)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (telefono == null)
            {
                return NotFound();
            }

            return View(telefono);
        }

        
        public IActionResult Create()
        {
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmpleadoId,Numero")] Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telefono);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido", telefono.EmpleadoId);
            return View(telefono);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await _context.Telefonos.FindAsync(id);
            if (telefono == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido", telefono.EmpleadoId);
            return View(telefono);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmpleadoId,Numero")] Telefono telefono)
        {
            if (id != telefono.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telefono);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefonoExists(telefono.Id))
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido", telefono.EmpleadoId);
            return View(telefono);
        }

      
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = await _context.Telefonos
                .Include(t => t.Empleado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telefono == null)
            {
                return NotFound();
            }

            return View(telefono);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var telefono = await _context.Telefonos.FindAsync(id);
            _context.Telefonos.Remove(telefono);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefonoExists(int id)
        {
            return _context.Telefonos.Any(e => e.Id == id);
        }
    }
}
