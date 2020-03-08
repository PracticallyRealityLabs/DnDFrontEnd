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
    public class SpellListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpellListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SpellLists
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SpellList.Include(s => s.Character);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SpellLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spellList = await _context.SpellList
                .Include(s => s.Character)
                .FirstOrDefaultAsync(m => m.Spelllistid == id);
            if (spellList == null)
            {
                return NotFound();
            }

            return View(spellList);
        }

        // GET: SpellLists/Create
        public IActionResult Create()
        {
            ViewData["Characterid"] = new SelectList(_context.PlayerCharacter, "PlayerCharacterid", "PlayerCharacterid");
            return View();
        }

        // POST: SpellLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Spelllistid,Characterid")] SpellList spellList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spellList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Characterid"] = new SelectList(_context.PlayerCharacter, "PlayerCharacterid", "PlayerCharacterid", spellList.Characterid);
            return View(spellList);
        }

        // GET: SpellLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spellList = await _context.SpellList.FindAsync(id);
            if (spellList == null)
            {
                return NotFound();
            }
            ViewData["Characterid"] = new SelectList(_context.PlayerCharacter, "PlayerCharacterid", "PlayerCharacterid", spellList.Characterid);
            return View(spellList);
        }

        // POST: SpellLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Spelllistid,Characterid")] SpellList spellList)
        {
            if (id != spellList.Spelllistid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spellList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpellListExists(spellList.Spelllistid))
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
            ViewData["Characterid"] = new SelectList(_context.PlayerCharacter, "PlayerCharacterid", "PlayerCharacterid", spellList.Characterid);
            return View(spellList);
        }

        // GET: SpellLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spellList = await _context.SpellList
                .Include(s => s.Character)
                .FirstOrDefaultAsync(m => m.Spelllistid == id);
            if (spellList == null)
            {
                return NotFound();
            }

            return View(spellList);
        }

        // POST: SpellLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spellList = await _context.SpellList.FindAsync(id);
            _context.SpellList.Remove(spellList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpellListExists(int id)
        {
            return _context.SpellList.Any(e => e.Spelllistid == id);
        }
    }
}
