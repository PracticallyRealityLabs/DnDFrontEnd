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
    public class SpellListHasSpellsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpellListHasSpellsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SpellListHasSpells
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SpellListHasSpells.Include(s => s.Spell).Include(s => s.SpellList);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SpellListHasSpells/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spellListHasSpells = await _context.SpellListHasSpells
                .Include(s => s.Spell)
                .Include(s => s.SpellList)
                .FirstOrDefaultAsync(m => m.SpellListHasSpellsid == id);
            if (spellListHasSpells == null)
            {
                return NotFound();
            }

            return View(spellListHasSpells);
        }

        // GET: SpellListHasSpells/Create
        public IActionResult Create()
        {
            ViewData["Spellid"] = new SelectList(_context.Set<Spells>(), "Spellsid", "Spellsid");
            ViewData["SpellListId"] = new SelectList(_context.SpellList, "Spelllistid", "Spelllistid");
            return View();
        }

        // POST: SpellListHasSpells/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpellListHasSpellsid,SpellListId,Spellid")] SpellListHasSpells spellListHasSpells)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spellListHasSpells);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Spellid"] = new SelectList(_context.Set<Spells>(), "Spellsid", "Spellsid", spellListHasSpells.Spellid);
            ViewData["SpellListId"] = new SelectList(_context.SpellList, "Spelllistid", "Spelllistid", spellListHasSpells.SpellListId);
            return View(spellListHasSpells);
        }

        // GET: SpellListHasSpells/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spellListHasSpells = await _context.SpellListHasSpells.FindAsync(id);
            if (spellListHasSpells == null)
            {
                return NotFound();
            }
            ViewData["Spellid"] = new SelectList(_context.Set<Spells>(), "Spellsid", "Spellsid", spellListHasSpells.Spellid);
            ViewData["SpellListId"] = new SelectList(_context.SpellList, "Spelllistid", "Spelllistid", spellListHasSpells.SpellListId);
            return View(spellListHasSpells);
        }

        // POST: SpellListHasSpells/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("SpellListHasSpellsid,SpellListId,Spellid")] SpellListHasSpells spellListHasSpells)
        {
            if (id != spellListHasSpells.SpellListHasSpellsid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spellListHasSpells);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpellListHasSpellsExists(spellListHasSpells.SpellListHasSpellsid))
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
            ViewData["Spellid"] = new SelectList(_context.Set<Spells>(), "Spellsid", "Spellsid", spellListHasSpells.Spellid);
            ViewData["SpellListId"] = new SelectList(_context.SpellList, "Spelllistid", "Spelllistid", spellListHasSpells.SpellListId);
            return View(spellListHasSpells);
        }

        // GET: SpellListHasSpells/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spellListHasSpells = await _context.SpellListHasSpells
                .Include(s => s.Spell)
                .Include(s => s.SpellList)
                .FirstOrDefaultAsync(m => m.SpellListHasSpellsid == id);
            if (spellListHasSpells == null)
            {
                return NotFound();
            }

            return View(spellListHasSpells);
        }

        // POST: SpellListHasSpells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var spellListHasSpells = await _context.SpellListHasSpells.FindAsync(id);
            _context.SpellListHasSpells.Remove(spellListHasSpells);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpellListHasSpellsExists(int? id)
        {
            return _context.SpellListHasSpells.Any(e => e.SpellListHasSpellsid == id);
        }
    }
}
