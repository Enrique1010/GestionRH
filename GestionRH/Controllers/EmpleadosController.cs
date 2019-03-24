﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionRH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GestionRH.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly GestionRHContext _context;

        public EmpleadosController(GestionRHContext context)
        {
            _context = context;
        }

        // GET: MantenimientoEmpleadoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MantenimientoEmpleado.ToListAsync());
        }

        // GET: MantenimientoEmpleadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mantenimientoEmpleado = await _context.MantenimientoEmpleado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mantenimientoEmpleado == null)
            {
                return NotFound();
            }

            return View(mantenimientoEmpleado);
        }

        // GET: MantenimientoEmpleadoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MantenimientoEmpleadoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodigoEmpleado,Nombre,Apellido,Telefono,Departamento,FechaIngreso,Salario,Estatus,Cargo")] MantenimientoEmpleado mantenimientoEmpleado)
        {
            var tel = from m in _context.MantenimientoEmpleado select m;
            if (!String.IsNullOrEmpty(mantenimientoEmpleado.Telefono))
            {
                tel.Where(m => m.Telefono.Contains(mantenimientoEmpleado.Telefono));
            }
            if (ModelState.IsValid)
            {
                tel.Where(m => m.Telefono.Contains(mantenimientoEmpleado.Telefono));
                mantenimientoEmpleado.Estatus = true;
                _context.Add(mantenimientoEmpleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mantenimientoEmpleado);
        }

        // GET: MantenimientoEmpleadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mantenimientoEmpleado = await _context.MantenimientoEmpleado.FindAsync(id);
            if (mantenimientoEmpleado == null)
            {
                return NotFound();
            }
            return View(mantenimientoEmpleado);
        }

        // POST: MantenimientoEmpleadoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodigoEmpleado,Nombre,Apellido,Telefono,Departamento,FechaIngreso,Salario,Estatus,Cargo")] MantenimientoEmpleado mantenimientoEmpleado)
        {
            if (id != mantenimientoEmpleado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mantenimientoEmpleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MantenimientoEmpleadoExists(mantenimientoEmpleado.Id))
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
            return View(mantenimientoEmpleado);
        }

        // GET: MantenimientoEmpleadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mantenimientoEmpleado = await _context.MantenimientoEmpleado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mantenimientoEmpleado == null)
            {
                return NotFound();
            }

            return View(mantenimientoEmpleado);
        }

        // POST: MantenimientoEmpleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mantenimientoEmpleado = await _context.MantenimientoEmpleado.FindAsync(id);
            _context.MantenimientoEmpleado.Remove(mantenimientoEmpleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MantenimientoEmpleadoExists(int id)
        {
            return _context.MantenimientoEmpleado.Any(e => e.Id == id);
        }
    }
}