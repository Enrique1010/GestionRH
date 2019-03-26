using System;
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

        // GET: MantenimientoEmpleados
        public async Task<IActionResult> Index()
        {
            return View(await _context.MantenimientoEmpleado.ToListAsync());
        }
        //get empleados inactivos
        public async Task<IActionResult> Inactivo()
        {
            return View(await _context.MantenimientoEmpleado.ToListAsync());
        }

        //busqueda por nombre y fecha
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string busqueda, string fecha)
        {
            var nombres = from s in _context.MantenimientoEmpleado
                           select s;
            if (!String.IsNullOrEmpty(busqueda))
            {
                nombres = nombres.Where(s => s.Nombre.Contains(busqueda));
            }
            else if (!String.IsNullOrEmpty(fecha))
            {
                DateTime fechax = DateTime.Parse(fecha);
                nombres = nombres.Where(s => s.FechaIngreso.Equals(fechax));
            }

            return View(await nombres.AsNoTracking().ToListAsync());

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
            if (ModelState.IsValid)
            {
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

            var mantenimientoEmpleado = await _context.MantenimientoEmpleado
                .FindAsync(id);
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


        //guarda el monto total de la nomina en la base de datos
        public async Task<IActionResult> GuardarRegistro(ProcessNominas p, MantenimientoEmpleado empleado)
        {
                p.Mes = DateTime.Today;
                p.Age = DateTime.Now;
                var nom = from m in _context.MantenimientoEmpleado where (m.Estatus == true) select m.Salario;
                p.MontoTotal = nom.Sum();
                _context.Add(p);
                await _context.SaveChangesAsync();

            return View(p);
        }

        //Registrar Vacaciones para empleados
        public IActionResult Vacaciones()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //procesar las vacaciones en la bdd
        public async Task<IActionResult> Vacaciones([Bind("Id,Empleado,Desde,Hasta,Correspondiente,Comentario")] ProcessVacaciones vacaciones)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(vacaciones);
                    //_context.Update(empleado);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToAction(nameof(Index));
                }    
            }
            return View(vacaciones);
        }
        //Registrar Permisos para empleados
        public IActionResult Permisos()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //procesar los permisos en la bdd
        public async Task<IActionResult> Permisos([Bind("Id,Empleado,Desde,Hasta,Comentario")] ProcessPermisos permisos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(permisos);
                    //_context.Update(empleado);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(permisos);
        }

        //Registrar Licencias para empleados
        public IActionResult Licencias()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //procesar los permisos en la bdd
        public async Task<IActionResult> Licencias([Bind("Id,Empleado,Desde,Hasta,Comentario,Motivo")] ProcessLicencias licencias)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(licencias);
                    //_context.Update(empleado);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(licencias);
        }
        //mostrar Vacaciones
        public async Task<IActionResult> Vacacionesx()
        {
            return View(await _context.ProcessVacaciones.ToListAsync());
        }
        //mostrar licencias
        public async Task<IActionResult> Licenciasx()
        {
            return View(await _context.ProcessLicencias.ToListAsync());
        }
        //mostrar Permisos
        public async Task<IActionResult> Permisosx()
        {
            return View(await _context.ProcessPermisos.ToListAsync());
        }

        //comprueba si los id de las tablas a mostrar existen
        private bool MantenimientoEmpleadoExists(int id)
        {
            return _context.MantenimientoEmpleado.Any(e => e.Id == id);
        }
    }
}
