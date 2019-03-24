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
    public class DepartamentosController : Controller
    {
        private readonly GestionRHContext _context;

        public DepartamentosController(GestionRHContext context)
        {
            _context = context;
        }

        // GET: Departamentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.MantenimientoDepartamento.ToListAsync());
        }

        // GET: Departamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mantenimientoDepartamento = await _context.MantenimientoDepartamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mantenimientoDepartamento == null)
            {
                return NotFound();
            }

            return View(mantenimientoDepartamento);
        }

        // GET: Departamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodigoDepartamento,Nombre")] MantenimientoDepartamento mantenimientoDepartamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mantenimientoDepartamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mantenimientoDepartamento);
        }

        // GET: Departamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mantenimientoDepartamento = await _context.MantenimientoDepartamento.FindAsync(id);
            if (mantenimientoDepartamento == null)
            {
                return NotFound();
            }
            return View(mantenimientoDepartamento);
        }

        // POST: Departamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodigoDepartamento,Nombre")] MantenimientoDepartamento mantenimientoDepartamento)
        {
            if (id != mantenimientoDepartamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mantenimientoDepartamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MantenimientoDepartamentoExists(mantenimientoDepartamento.Id))
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
            return View(mantenimientoDepartamento);
        }

        // GET: Departamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mantenimientoDepartamento = await _context.MantenimientoDepartamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mantenimientoDepartamento == null)
            {
                return NotFound();
            }

            return View(mantenimientoDepartamento);
        }

        // POST: Departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mantenimientoDepartamento = await _context.MantenimientoDepartamento.FindAsync(id);
            _context.MantenimientoDepartamento.Remove(mantenimientoDepartamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MantenimientoDepartamentoExists(int id)
        {
            return _context.MantenimientoDepartamento.Any(e => e.Id == id);
        }
    }
}
