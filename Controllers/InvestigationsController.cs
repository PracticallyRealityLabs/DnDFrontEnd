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
    public class InvestigationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvestigationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Investigations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Investigation.ToListAsync());
        }

        // GET: Investigations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investigation = await _context.Investigation
                .FirstOrDefaultAsync(m => m.Investigationid == id);
            if (investigation == null)
            {
                return NotFound();
            }

            return View(investigation);
        }

        // GET: Investigations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Investigations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Investigationid,Investigationprof")] Investigation investigation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(investigation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(investigation);
        }

        // GET: Investigations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investigation = await _context.Investigation.FindAsync(id);
            if (investigation == null)
            {
                return NotFound();
            }
            return View(investigation);
        }

        // POST: Investigations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Investigationid,Investigationprof")] Investigation investigation)
        {
            if (id != investigation.Investigationid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(investigation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvestigationExists(investigation.Investigationid))
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
            return View(investigation);
        }

        // GET: Investigations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investigation = await _context.Investigation
                .FirstOrDefaultAsync(m => m.Investigationid == id);
            if (investigation == null)
            {
                return NotFound();
            }

            return View(investigation);
        }

        // POST: Investigations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var investigation = await _context.Investigation.FindAsync(id);
            _context.Investigation.Remove(investigation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvestigationExists(int id)
        {
            return _context.Investigation.Any(e => e.Investigationid == id);
        }
    }
}
