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
    public class utilisateursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public utilisateursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: utilisateurs
        public async Task<IActionResult> Index()
        {
              return _context.utilisateur != null ? 
                          View(await _context.utilisateur.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.utilisateur'  is null.");
        }

        // GET: utilisateurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.utilisateur == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.utilisateur
                .FirstOrDefaultAsync(m => m.id == id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            return View(utilisateur);
        }

        // GET: utilisateurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: utilisateurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,Age,longueur,Pied,Role,tel,Email")] utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utilisateur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utilisateur);
        }

        // GET: utilisateurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.utilisateur == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.utilisateur.FindAsync(id);
            if (utilisateur == null)
            {
                return NotFound();
            }
            return View(utilisateur);
        }

        // POST: utilisateurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,Age,longueur,Pied,Role,tel,Email")] utilisateur utilisateur)
        {
            if (id != utilisateur.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilisateur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!utilisateurExists(utilisateur.id))
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
            return View(utilisateur);
        }

        // GET: utilisateurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.utilisateur == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.utilisateur
                .FirstOrDefaultAsync(m => m.id == id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            return View(utilisateur);
        }

        // POST: utilisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.utilisateur == null)
            {
                return Problem("Entity set 'ApplicationDbContext.utilisateur'  is null.");
            }
            var utilisateur = await _context.utilisateur.FindAsync(id);
            if (utilisateur != null)
            {
                _context.utilisateur.Remove(utilisateur);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool utilisateurExists(int id)
        {
          return (_context.utilisateur?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
