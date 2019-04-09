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
    public class SalidaController : Controller
    {
        private readonly GestionRHContext _context;

        public SalidaController(GestionRHContext context)
        {
            _context = context;
        }

        // GET: Salida
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProcessSalidaEmpleado.ToListAsync());
        }

        // GET: Salida/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processSalidaEmpleado = await _context.ProcessSalidaEmpleado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (processSalidaEmpleado == null)
            {
                return NotFound();
            }

            return View(processSalidaEmpleado);
        }
        // GET: Salida/Create
        public IActionResult Create()
        {
                List<string> empleados = new List<string>();
                var vd = from em in _context.MantenimientoEmpleado where (em.Estatus == true) select em;
                foreach (var item in vd)
                {
                    empleados.Add(item.Nombre);
                    ViewBag.emps = empleados;
                }

                return View();
        }

        // POST: Salida/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Empleado,TipoDeSalida,Motivo,Fecha,Id")] ProcessSalidaEmpleado processSalidaEmpleado)
        {
            if (ModelState.IsValid)
            {
                var salida = (from m in _context.MantenimientoEmpleado where m.Nombre == processSalidaEmpleado.Empleado select m).First();
                salida.Estatus = false;
                _context.Add(processSalidaEmpleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View("Fallos");
        }

        // GET: Salida/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processSalidaEmpleado = await _context.ProcessSalidaEmpleado.FindAsync(id);
            if (processSalidaEmpleado == null)
            {
                return NotFound();
            }
            return View(processSalidaEmpleado);
        }

        // POST: Salida/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Empleado,TipoDeSalida,Motivo,Fecha,Id")] ProcessSalidaEmpleado processSalidaEmpleado)
        {
            if (id != processSalidaEmpleado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(processSalidaEmpleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcessSalidaEmpleadoExists(processSalidaEmpleado.Id))
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
            return View(processSalidaEmpleado);
        }

        // GET: Salida/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processSalidaEmpleado = await _context.ProcessSalidaEmpleado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (processSalidaEmpleado == null)
            {
                return NotFound();
            }

            return View(processSalidaEmpleado);
        }

        // POST: Salida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var processSalidaEmpleado = await _context.ProcessSalidaEmpleado.FindAsync(id);
            _context.ProcessSalidaEmpleado.Remove(processSalidaEmpleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //registrar fallos en una vista
        public IActionResult Fallos()
        {
            return View();
        }

        private bool ProcessSalidaEmpleadoExists(int id)
        {
            return _context.ProcessSalidaEmpleado.Any(e => e.Id == id);
        }
    }
}
