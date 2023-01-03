using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IFootWebProject.Data;
using IFootWebProject.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace IFootWebProject.Controllers
{
    public class EvenementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EvenementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Evenements
        public async Task<IActionResult> List()
        {
            var applicationDbContext = _context.Evenement.Include(e => e.Terrain);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Evenements
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Evenement.Include(e => e.Terrain);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Evenements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Evenement == null)
            {
                return NotFound();
            }

            var evenement = await _context.Evenement
                .Include(e => e.Terrain)
                .FirstOrDefaultAsync(m => m.id == id);
            if (evenement == null)
            {
                return NotFound();
            }

            return View(evenement);
        }

        // GET: Evenements/Create
        public IActionResult Create()
        {
            ViewData["idTerrain"] = new SelectList(_context.Set<Terrain>(), "id", "id");
            return View();
        }

        // POST: Evenements/Create [Bind("id,Prix,dateEvent,heure,Etat,idUtilisateur,idTerrain,idTypeEven")]
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Evenement evenement)
        {

            
                var liste = new Evenement();

          
            if (ModelState.IsValid)
            {
                liste.id = evenement.id;
                liste.Prix = evenement.Prix;
                liste.dateEvent = evenement.dateEvent;
                liste.heure = evenement.heure;
                liste.Etat = "active";
                liste.idUtilisateur = 1;
                liste.idTerrain = evenement.idTerrain;
                liste.idTypeEven = evenement.idTypeEven;

                _context.Add(evenement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idTerrain"] = new SelectList(_context.Set<Terrain>(), "id", "id", evenement.idTerrain);
            return View(evenement);
        }

        // GET: Evenements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Evenement == null)
            {
                return NotFound();
            }

            var evenement = await _context.Evenement.FindAsync(id);
            if (evenement == null)
            {
                return NotFound();
            }
            ViewData["idTerrain"] = new SelectList(_context.Set<Terrain>(), "id", "id", evenement.idTerrain);
            return View(evenement);
        }

        // POST: Evenements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Prix,dateEvent,heure,Etat,idUtilisateur,idTerrain,idTypeEven")] Evenement evenement)
        {
            if (id != evenement.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evenement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvenementExists(evenement.id))
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
            ViewData["idTerrain"] = new SelectList(_context.Set<Terrain>(), "id", "id", evenement.idTerrain);
            return View(evenement);
        }

        // GET: Evenements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Evenement == null)
            {
                return NotFound();
            }

            var evenement = await _context.Evenement
                .Include(e => e.Terrain)
                .FirstOrDefaultAsync(m => m.id == id);
            if (evenement == null)
            {
                return NotFound();
            }

            return View(evenement);
        }

        // POST: Evenements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Evenement == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Evenement'  is null.");
            }
            var evenement = await _context.Evenement.FindAsync(id);
            if (evenement != null)
            {
                _context.Evenement.Remove(evenement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvenementExists(int id)
        {
          return (_context.Evenement?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
