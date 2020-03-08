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
    public class WisdomsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WisdomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Wisdoms
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Wisdom.Include(w => w.Animalhand).Include(w => w.Insight).Include(w => w.Perception).Include(w => w.Survival);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Wisdoms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wisdom = await _context.Wisdom
                .Include(w => w.Animalhand)
                .Include(w => w.Insight)
                .Include(w => w.Perception)
                .Include(w => w.Survival)
                .FirstOrDefaultAsync(m => m.Wisdomid == id);
            if (wisdom == null)
            {
                return NotFound();
            }

            return View(wisdom);
        }

        // GET: Wisdoms/Create
        public IActionResult Create()
        {
            ViewData["Animalhandid"] = new SelectList(_context.AnimalHandling, "AnimalHandlingId", "AnimalHandlingId");
            ViewData["Insightid"] = new SelectList(_context.Insight, "Insightid", "Insightid");
            ViewData["Perceptionid"] = new SelectList(_context.Perception, "Perceptionid", "Perceptionid");
            ViewData["Survivalid"] = new SelectList(_context.Survival, "Survivalid", "Survivalid");
            return View();
        }

        // POST: Wisdoms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Wisdomid,Wissaveprof,Wisvalue,Animalhandid,Perceptionid,Insightid,Survivalid")] Wisdom wisdom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wisdom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Animalhandid"] = new SelectList(_context.AnimalHandling, "AnimalHandlingId", "AnimalHandlingId", wisdom.Animalhandid);
            ViewData["Insightid"] = new SelectList(_context.Insight, "Insightid", "Insightid", wisdom.Insightid);
            ViewData["Perceptionid"] = new SelectList(_context.Perception, "Perceptionid", "Perceptionid", wisdom.Perceptionid);
            ViewData["Survivalid"] = new SelectList(_context.Survival, "Survivalid", "Survivalid", wisdom.Survivalid);
            return View(wisdom);
        }

        // GET: Wisdoms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wisdom = await _context.Wisdom.FindAsync(id);
            if (wisdom == null)
            {
                return NotFound();
            }
            ViewData["Animalhandid"] = new SelectList(_context.AnimalHandling, "AnimalHandlingId", "AnimalHandlingId", wisdom.Animalhandid);
            ViewData["Insightid"] = new SelectList(_context.Insight, "Insightid", "Insightid", wisdom.Insightid);
            ViewData["Perceptionid"] = new SelectList(_context.Perception, "Perceptionid", "Perceptionid", wisdom.Perceptionid);
            ViewData["Survivalid"] = new SelectList(_context.Survival, "Survivalid", "Survivalid", wisdom.Survivalid);
            return View(wisdom);
        }

        // POST: Wisdoms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Wisdomid,Wissaveprof,Wisvalue,Animalhandid,Perceptionid,Insightid,Survivalid")] Wisdom wisdom)
        {
            if (id != wisdom.Wisdomid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wisdom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WisdomExists(wisdom.Wisdomid))
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
            ViewData["Animalhandid"] = new SelectList(_context.AnimalHandling, "AnimalHandlingId", "AnimalHandlingId", wisdom.Animalhandid);
            ViewData["Insightid"] = new SelectList(_context.Insight, "Insightid", "Insightid", wisdom.Insightid);
            ViewData["Perceptionid"] = new SelectList(_context.Perception, "Perceptionid", "Perceptionid", wisdom.Perceptionid);
            ViewData["Survivalid"] = new SelectList(_context.Survival, "Survivalid", "Survivalid", wisdom.Survivalid);
            return View(wisdom);
        }

        // GET: Wisdoms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wisdom = await _context.Wisdom
                .Include(w => w.Animalhand)
                .Include(w => w.Insight)
                .Include(w => w.Perception)
                .Include(w => w.Survival)
                .FirstOrDefaultAsync(m => m.Wisdomid == id);
            if (wisdom == null)
            {
                return NotFound();
            }

            return View(wisdom);
        }

        // POST: Wisdoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wisdom = await _context.Wisdom.FindAsync(id);
            _context.Wisdom.Remove(wisdom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WisdomExists(int id)
        {
            return _context.Wisdom.Any(e => e.Wisdomid == id);
        }
    }
}
