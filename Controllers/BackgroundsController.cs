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
    public class BackgroundsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BackgroundsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Backgrounds
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Background.Include(b => b.Character);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Backgrounds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var background = await _context.Background
                .Include(b => b.Character)
                .FirstOrDefaultAsync(m => m.Backgroundid == id);
            if (background == null)
            {
                return NotFound();
            }

            return View(background);
        }

        // GET: Backgrounds/Create
        public IActionResult Create()
        {
            ViewData["Characterid"] = new SelectList(_context.Set<PlayerCharacter>(), "PlayerCharacterid", "PlayerCharacterid");
            return View();
        }

        // POST: Backgrounds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Backgroundid,Description,Bonds,Flaws,Ideals,Traits,Backgroundtype,Characterid")] Background background)
        {
            if (ModelState.IsValid)
            {
                _context.Add(background);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Characterid"] = new SelectList(_context.Set<PlayerCharacter>(), "PlayerCharacterid", "PlayerCharacterid", background.Characterid);
            return View(background);
        }

        // GET: Backgrounds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var background = await _context.Background.FindAsync(id);
            if (background == null)
            {
                return NotFound();
            }
            ViewData["Characterid"] = new SelectList(_context.Set<PlayerCharacter>(), "PlayerCharacterid", "PlayerCharacterid", background.Characterid);
            return View(background);
        }

        // POST: Backgrounds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Backgroundid,Description,Bonds,Flaws,Ideals,Traits,Backgroundtype,Characterid")] Background background)
        {
            if (id != background.Backgroundid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(background);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BackgroundExists(background.Backgroundid))
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
            ViewData["Characterid"] = new SelectList(_context.Set<PlayerCharacter>(), "PlayerCharacterid", "PlayerCharacterid", background.Characterid);
            return View(background);
        }

        // GET: Backgrounds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var background = await _context.Background
                .Include(b => b.Character)
                .FirstOrDefaultAsync(m => m.Backgroundid == id);
            if (background == null)
            {
                return NotFound();
            }

            return View(background);
        }

        // POST: Backgrounds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var background = await _context.Background.FindAsync(id);
            _context.Background.Remove(background);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BackgroundExists(int id)
        {
            return _context.Background.Any(e => e.Backgroundid == id);
        }
    }
}
