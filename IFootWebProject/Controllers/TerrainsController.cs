using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IFootWebProject.Data;
using IFootWebProject.Models;

namespace IFootWebProject.Controllers
{
    public class TerrainsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TerrainsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Terrains
        public async Task<IActionResult> Index()
        {
              return _context.Terrain != null ? 
                          View(await _context.Terrain.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Terrain'  is null.");
        }

        // GET: Terrains/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Terrain == null)
            {
                return NotFound();
            }

            var terrain = await _context.Terrain
                .FirstOrDefaultAsync(m => m.id == id);
            if (terrain == null)
            {
                return NotFound();
            }

            return View(terrain);
        }

        // GET: Terrains/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Terrains/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Nom,Localisation,Prix,Type")] Terrain terrain)
        {
            if (ModelState.IsValid)
            {
                _context.Add(terrain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(terrain);
        }

        // GET: Terrains/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Terrain == null)
            {
                return NotFound();
            }

            var terrain = await _context.Terrain.FindAsync(id);
            if (terrain == null)
            {
                return NotFound();
            }
            return View(terrain);
        }

        // POST: Terrains/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Nom,Localisation,Prix,Type")] Terrain terrain)
        {
            if (id != terrain.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(terrain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TerrainExists(terrain.id))
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
            return View(terrain);
        }

        // GET: Terrains/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Terrain == null)
            {
                return NotFound();
            }

            var terrain = await _context.Terrain
                .FirstOrDefaultAsync(m => m.id == id);
            if (terrain == null)
            {
                return NotFound();
            }

            return View(terrain);
        }

        // POST: Terrains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Terrain == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Terrain'  is null.");
            }
            var terrain = await _context.Terrain.FindAsync(id);
            if (terrain != null)
            {
                _context.Terrain.Remove(terrain);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TerrainExists(int id)
        {
          return (_context.Terrain?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
