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
    public class IntelligencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IntelligencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Intelligences
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Intelligence.Include(i => i.Arcana).Include(i => i.History).Include(i => i.Investigation).Include(i => i.Nature).Include(i => i.Religion);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Intelligences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intelligence = await _context.Intelligence
                .Include(i => i.Arcana)
                .Include(i => i.History)
                .Include(i => i.Investigation)
                .Include(i => i.Nature)
                .Include(i => i.Religion)
                .FirstOrDefaultAsync(m => m.Intelligenceid == id);
            if (intelligence == null)
            {
                return NotFound();
            }

            return View(intelligence);
        }

        // GET: Intelligences/Create
        public IActionResult Create()
        {
            ViewData["Arcanaid"] = new SelectList(_context.Arcana, "Arcanaid", "Arcanaid");
            ViewData["Historyid"] = new SelectList(_context.History, "Historyid", "Historyid");
            ViewData["Investigationid"] = new SelectList(_context.Set<Investigation>(), "Investigationid", "Investigationid");
            ViewData["Natureid"] = new SelectList(_context.Set<Nature>(), "Natureid", "Natureid");
            ViewData["Religionid"] = new SelectList(_context.Set<Religion>(), "Religionid", "Religionid");
            return View();
        }

        // POST: Intelligences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Intelligenceid,Intvalue,Intsaveprof,Investigationid,Historyid,Arcanaid,Natureid,Religionid")] Intelligence intelligence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(intelligence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Arcanaid"] = new SelectList(_context.Arcana, "Arcanaid", "Arcanaid", intelligence.Arcanaid);
            ViewData["Historyid"] = new SelectList(_context.History, "Historyid", "Historyid", intelligence.Historyid);
            ViewData["Investigationid"] = new SelectList(_context.Set<Investigation>(), "Investigationid", "Investigationid", intelligence.Investigationid);
            ViewData["Natureid"] = new SelectList(_context.Set<Nature>(), "Natureid", "Natureid", intelligence.Natureid);
            ViewData["Religionid"] = new SelectList(_context.Set<Religion>(), "Religionid", "Religionid", intelligence.Religionid);
            return View(intelligence);
        }

        // GET: Intelligences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intelligence = await _context.Intelligence.FindAsync(id);
            if (intelligence == null)
            {
                return NotFound();
            }
            ViewData["Arcanaid"] = new SelectList(_context.Arcana, "Arcanaid", "Arcanaid", intelligence.Arcanaid);
            ViewData["Historyid"] = new SelectList(_context.History, "Historyid", "Historyid", intelligence.Historyid);
            ViewData["Investigationid"] = new SelectList(_context.Set<Investigation>(), "Investigationid", "Investigationid", intelligence.Investigationid);
            ViewData["Natureid"] = new SelectList(_context.Set<Nature>(), "Natureid", "Natureid", intelligence.Natureid);
            ViewData["Religionid"] = new SelectList(_context.Set<Religion>(), "Religionid", "Religionid", intelligence.Religionid);
            return View(intelligence);
        }

        // POST: Intelligences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Intelligenceid,Intvalue,Intsaveprof,Investigationid,Historyid,Arcanaid,Natureid,Religionid")] Intelligence intelligence)
        {
            if (id != intelligence.Intelligenceid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(intelligence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IntelligenceExists(intelligence.Intelligenceid))
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
            ViewData["Arcanaid"] = new SelectList(_context.Arcana, "Arcanaid", "Arcanaid", intelligence.Arcanaid);
            ViewData["Historyid"] = new SelectList(_context.History, "Historyid", "Historyid", intelligence.Historyid);
            ViewData["Investigationid"] = new SelectList(_context.Set<Investigation>(), "Investigationid", "Investigationid", intelligence.Investigationid);
            ViewData["Natureid"] = new SelectList(_context.Set<Nature>(), "Natureid", "Natureid", intelligence.Natureid);
            ViewData["Religionid"] = new SelectList(_context.Set<Religion>(), "Religionid", "Religionid", intelligence.Religionid);
            return View(intelligence);
        }

        // GET: Intelligences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intelligence = await _context.Intelligence
                .Include(i => i.Arcana)
                .Include(i => i.History)
                .Include(i => i.Investigation)
                .Include(i => i.Nature)
                .Include(i => i.Religion)
                .FirstOrDefaultAsync(m => m.Intelligenceid == id);
            if (intelligence == null)
            {
                return NotFound();
            }

            return View(intelligence);
        }

        // POST: Intelligences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var intelligence = await _context.Intelligence.FindAsync(id);
            _context.Intelligence.Remove(intelligence);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IntelligenceExists(int id)
        {
            return _context.Intelligence.Any(e => e.Intelligenceid == id);
        }
    }
}
