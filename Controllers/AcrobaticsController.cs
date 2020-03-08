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
    public class AcrobaticsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AcrobaticsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Acrobatics
        public async Task<IActionResult> Index()
        {
            return View(await _context.Acrobatics.ToListAsync());
        }

        // GET: Acrobatics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acrobatics = await _context.Acrobatics
                .FirstOrDefaultAsync(m => m.Acrobaticsid == id);
            if (acrobatics == null)
            {
                return NotFound();
            }

            return View(acrobatics);
        }

        // GET: Acrobatics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Acrobatics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Acrobaticsid,Acrobaticsprof")] Acrobatics acrobatics)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acrobatics);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(acrobatics);
        }

        // GET: Acrobatics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acrobatics = await _context.Acrobatics.FindAsync(id);
            if (acrobatics == null)
            {
                return NotFound();
            }
            return View(acrobatics);
        }

        // POST: Acrobatics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Acrobaticsid,Acrobaticsprof")] Acrobatics acrobatics)
        {
            if (id != acrobatics.Acrobaticsid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acrobatics);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcrobaticsExists(acrobatics.Acrobaticsid))
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
            return View(acrobatics);
        }

        // GET: Acrobatics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acrobatics = await _context.Acrobatics
                .FirstOrDefaultAsync(m => m.Acrobaticsid == id);
            if (acrobatics == null)
            {
                return NotFound();
            }

            return View(acrobatics);
        }

        // POST: Acrobatics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acrobatics = await _context.Acrobatics.FindAsync(id);
            _context.Acrobatics.Remove(acrobatics);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcrobaticsExists(int id)
        {
            return _context.Acrobatics.Any(e => e.Acrobaticsid == id);
        }
    }
}
