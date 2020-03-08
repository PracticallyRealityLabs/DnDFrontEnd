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
    public class StrengthsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StrengthsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Strengths
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Strength.Include(s => s.Athletics);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Strengths/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var strength = await _context.Strength
                .Include(s => s.Athletics)
                .FirstOrDefaultAsync(m => m.Strengthid == id);
            if (strength == null)
            {
                return NotFound();
            }

            return View(strength);
        }

        // GET: Strengths/Create
        public IActionResult Create()
        {
            ViewData["Athleticsid"] = new SelectList(_context.Athletics, "Athleticsid", "Athleticsid");
            return View();
        }

        // POST: Strengths/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Strengthid,Strsaveprof,Strvalue,Athleticsid")] Strength strength)
        {
            if (ModelState.IsValid)
            {
                _context.Add(strength);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Athleticsid"] = new SelectList(_context.Athletics, "Athleticsid", "Athleticsid", strength.Athleticsid);
            return View(strength);
        }

        // GET: Strengths/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var strength = await _context.Strength.FindAsync(id);
            if (strength == null)
            {
                return NotFound();
            }
            ViewData["Athleticsid"] = new SelectList(_context.Athletics, "Athleticsid", "Athleticsid", strength.Athleticsid);
            return View(strength);
        }

        // POST: Strengths/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Strengthid,Strsaveprof,Strvalue,Athleticsid")] Strength strength)
        {
            if (id != strength.Strengthid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(strength);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StrengthExists(strength.Strengthid))
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
            ViewData["Athleticsid"] = new SelectList(_context.Athletics, "Athleticsid", "Athleticsid", strength.Athleticsid);
            return View(strength);
        }

        // GET: Strengths/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var strength = await _context.Strength
                .Include(s => s.Athletics)
                .FirstOrDefaultAsync(m => m.Strengthid == id);
            if (strength == null)
            {
                return NotFound();
            }

            return View(strength);
        }

        // POST: Strengths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var strength = await _context.Strength.FindAsync(id);
            _context.Strength.Remove(strength);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StrengthExists(int id)
        {
            return _context.Strength.Any(e => e.Strengthid == id);
        }
    }
}
