using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AntambaJ_EvaluacionPrimerProgreso.Models;

namespace AntambaJ_EvaluacionPrimerProgreso.Controllers
{
    public class CitaVeterinariaController : Controller
    {
        private readonly SQLServerContext _context;

        public CitaVeterinariaController(SQLServerContext context)
        {
            _context = context;
        }

        // GET: CitaVeterinaria
        public async Task<IActionResult> Index()
        {
            var sQLServerContext = _context.CitaVeterinaria.Include(c => c.Mascota);
            return View(await sQLServerContext.ToListAsync());
        }

        // GET: CitaVeterinaria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citaVeterinaria = await _context.CitaVeterinaria
                .Include(c => c.Mascota)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (citaVeterinaria == null)
            {
                return NotFound();
            }

            return View(citaVeterinaria);
        }

        // GET: CitaVeterinaria/Create
        public IActionResult Create()
        {
            ViewData["MascotaId"] = new SelectList(_context.Mascota, "Id", "Nombre");
            return View();
        }

        // POST: CitaVeterinaria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaVisita,Motivo,RequiereMedicacion,MascotaId")] CitaVeterinaria citaVeterinaria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(citaVeterinaria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MascotaId"] = new SelectList(_context.Mascota, "Id", "Nombre", citaVeterinaria.MascotaId);
            return View(citaVeterinaria);
        }

        // GET: CitaVeterinaria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citaVeterinaria = await _context.CitaVeterinaria.FindAsync(id);
            if (citaVeterinaria == null)
            {
                return NotFound();
            }
            ViewData["MascotaId"] = new SelectList(_context.Mascota, "Id", "Nombre", citaVeterinaria.MascotaId);
            return View(citaVeterinaria);
        }

        // POST: CitaVeterinaria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaVisita,Motivo,RequiereMedicacion,MascotaId")] CitaVeterinaria citaVeterinaria)
        {
            if (id != citaVeterinaria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(citaVeterinaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitaVeterinariaExists(citaVeterinaria.Id))
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
            ViewData["MascotaId"] = new SelectList(_context.Mascota, "Id", "Nombre", citaVeterinaria.MascotaId);
            return View(citaVeterinaria);
        }

        // GET: CitaVeterinaria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citaVeterinaria = await _context.CitaVeterinaria
                .Include(c => c.Mascota)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (citaVeterinaria == null)
            {
                return NotFound();
            }

            return View(citaVeterinaria);
        }

        // POST: CitaVeterinaria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var citaVeterinaria = await _context.CitaVeterinaria.FindAsync(id);
            if (citaVeterinaria != null)
            {
                _context.CitaVeterinaria.Remove(citaVeterinaria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitaVeterinariaExists(int id)
        {
            return _context.CitaVeterinaria.Any(e => e.Id == id);
        }
    }
}
