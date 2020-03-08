using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DnDFrontEnd.Data;
using DnDFrontEnd.Models;

namespace DnDFrontEnd.Controllers
{
    public class SpellsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpellsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Spells
        public async Task<IActionResult> Index()
        {
            return View(await _context.Spells.ToListAsync());
        }

        // GET: Spells/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spells = await _context.Spells
                .FirstOrDefaultAsync(m => m.Spellsid == id);
            if (spells == null)
            {
                return NotFound();
            }

            return View(spells);
        }

        // GET: Spells/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Spells/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Spellsid,Spellname,School,Level,Range,Components,Duration,Description,Concentration")] Spells spells)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spells);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spells);
        }

        // GET: Spells/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spells = await _context.Spells.FindAsync(id);
            if (spells == null)
            {
                return NotFound();
            }
            return View(spells);
        }

        // POST: Spells/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Spellsid,Spellname,School,Level,Range,Components,Duration,Description,Concentration")] Spells spells)
        {
            if (id != spells.Spellsid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spells);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpellsExists(spells.Spellsid))
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
            return View(spells);
        }

        // GET: Spells/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spells = await _context.Spells
                .FirstOrDefaultAsync(m => m.Spellsid == id);
            if (spells == null)
            {
                return NotFound();
            }

            return View(spells);
        }

        // POST: Spells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spells = await _context.Spells.FindAsync(id);
            _context.Spells.Remove(spells);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpellsExists(int id)
        {
            return _context.Spells.Any(e => e.Spellsid == id);
        }
    }
}
