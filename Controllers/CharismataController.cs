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
    public class CharismataController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CharismataController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Charismata
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Charisma.Include(c => c.Deception).Include(c => c.Intimidation).Include(c => c.Performance).Include(c => c.Persuasion);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Charismata/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charisma = await _context.Charisma
                .Include(c => c.Deception)
                .Include(c => c.Intimidation)
                .Include(c => c.Performance)
                .Include(c => c.Persuasion)
                .FirstOrDefaultAsync(m => m.Charismaid == id);
            if (charisma == null)
            {
                return NotFound();
            }

            return View(charisma);
        }

        // GET: Charismata/Create
        public IActionResult Create()
        {
            ViewData["Deceptionid"] = new SelectList(_context.Set<Deception>(), "Deceptionid", "Deceptionid");
            ViewData["Intimidationid"] = new SelectList(_context.Set<Intimidation>(), "Intimidationid", "Intimidationid");
            ViewData["Performanceid"] = new SelectList(_context.Set<Performance>(), "Performanceid", "Performanceid");
            ViewData["Persuasionid"] = new SelectList(_context.Set<Persuasion>(), "Persuasionid", "Persuasionid");
            return View();
        }

        // POST: Charismata/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Charismaid,Chasaveprof,Chavalue,Persuasionid,Performanceid,Deceptionid,Intimidationid")] Charisma charisma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(charisma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Deceptionid"] = new SelectList(_context.Set<Deception>(), "Deceptionid", "Deceptionid", charisma.Deceptionid);
            ViewData["Intimidationid"] = new SelectList(_context.Set<Intimidation>(), "Intimidationid", "Intimidationid", charisma.Intimidationid);
            ViewData["Performanceid"] = new SelectList(_context.Set<Performance>(), "Performanceid", "Performanceid", charisma.Performanceid);
            ViewData["Persuasionid"] = new SelectList(_context.Set<Persuasion>(), "Persuasionid", "Persuasionid", charisma.Persuasionid);
            return View(charisma);
        }

        // GET: Charismata/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charisma = await _context.Charisma.FindAsync(id);
            if (charisma == null)
            {
                return NotFound();
            }
            ViewData["Deceptionid"] = new SelectList(_context.Set<Deception>(), "Deceptionid", "Deceptionid", charisma.Deceptionid);
            ViewData["Intimidationid"] = new SelectList(_context.Set<Intimidation>(), "Intimidationid", "Intimidationid", charisma.Intimidationid);
            ViewData["Performanceid"] = new SelectList(_context.Set<Performance>(), "Performanceid", "Performanceid", charisma.Performanceid);
            ViewData["Persuasionid"] = new SelectList(_context.Set<Persuasion>(), "Persuasionid", "Persuasionid", charisma.Persuasionid);
            return View(charisma);
        }

        // POST: Charismata/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Charismaid,Chasaveprof,Chavalue,Persuasionid,Performanceid,Deceptionid,Intimidationid")] Charisma charisma)
        {
            if (id != charisma.Charismaid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(charisma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharismaExists(charisma.Charismaid))
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
            ViewData["Deceptionid"] = new SelectList(_context.Set<Deception>(), "Deceptionid", "Deceptionid", charisma.Deceptionid);
            ViewData["Intimidationid"] = new SelectList(_context.Set<Intimidation>(), "Intimidationid", "Intimidationid", charisma.Intimidationid);
            ViewData["Performanceid"] = new SelectList(_context.Set<Performance>(), "Performanceid", "Performanceid", charisma.Performanceid);
            ViewData["Persuasionid"] = new SelectList(_context.Set<Persuasion>(), "Persuasionid", "Persuasionid", charisma.Persuasionid);
            return View(charisma);
        }

        // GET: Charismata/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charisma = await _context.Charisma
                .Include(c => c.Deception)
                .Include(c => c.Intimidation)
                .Include(c => c.Performance)
                .Include(c => c.Persuasion)
                .FirstOrDefaultAsync(m => m.Charismaid == id);
            if (charisma == null)
            {
                return NotFound();
            }

            return View(charisma);
        }

        // POST: Charismata/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var charisma = await _context.Charisma.FindAsync(id);
            _context.Charisma.Remove(charisma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharismaExists(int id)
        {
            return _context.Charisma.Any(e => e.Charismaid == id);
        }
    }
}
