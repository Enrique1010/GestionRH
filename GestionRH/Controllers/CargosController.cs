using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionRH.Models;

namespace GestionRH.Controllers
{
    public class CargosController : Controller
    {
        private readonly GestionRHContext _context;

        public CargosController(GestionRHContext context)
        {
            _context = context;
        }

        // GET: Cargos
        public async Task<IActionResult> Index()
        {
            return View(await _context.MantenimientoCargo.ToListAsync());
        }

        // GET: Cargos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mantenimientoCargo = await _context.MantenimientoCargo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mantenimientoCargo == null)
            {
                return NotFound();
            }

            return View(mantenimientoCargo);
        }

        // GET: Cargos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cargos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodigoCargo,NombreCargo")] MantenimientoCargo mantenimientoCargo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mantenimientoCargo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mantenimientoCargo);
        }

        // GET: Cargos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mantenimientoCargo = await _context.MantenimientoCargo.FindAsync(id);
            if (mantenimientoCargo == null)
            {
                return NotFound();
            }
            return View(mantenimientoCargo);
        }

        // POST: Cargos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodigoCargo,NombreCargo")] MantenimientoCargo mantenimientoCargo)
        {
            if (id != mantenimientoCargo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mantenimientoCargo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MantenimientoCargoExists(mantenimientoCargo.Id))
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
            return View(mantenimientoCargo);
        }

        // GET: Cargos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mantenimientoCargo = await _context.MantenimientoCargo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mantenimientoCargo == null)
            {
                return NotFound();
            }

            return View(mantenimientoCargo);
        }

        // POST: Cargos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mantenimientoCargo = await _context.MantenimientoCargo.FindAsync(id);
            _context.MantenimientoCargo.Remove(mantenimientoCargo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MantenimientoCargoExists(int id)
        {
            return _context.MantenimientoCargo.Any(e => e.Id == id);
        }
    }
}
