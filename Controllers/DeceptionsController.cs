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
    public class DeceptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeceptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Deceptions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Deception.ToListAsync());
        }

        // GET: Deceptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deception = await _context.Deception
                .FirstOrDefaultAsync(m => m.Deceptionid == id);
            if (deception == null)
            {
                return NotFound();
            }

            return View(deception);
        }

        // GET: Deceptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deceptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Deceptionid,Deceptionprof")] Deception deception)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deception);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deception);
        }

        // GET: Deceptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deception = await _context.Deception.FindAsync(id);
            if (deception == null)
            {
                return NotFound();
            }
            return View(deception);
        }

        // POST: Deceptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Deceptionid,Deceptionprof")] Deception deception)
        {
            if (id != deception.Deceptionid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deception);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeceptionExists(deception.Deceptionid))
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
            return View(deception);
        }

        // GET: Deceptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deception = await _context.Deception
                .FirstOrDefaultAsync(m => m.Deceptionid == id);
            if (deception == null)
            {
                return NotFound();
            }

            return View(deception);
        }

        // POST: Deceptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deception = await _context.Deception.FindAsync(id);
            _context.Deception.Remove(deception);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeceptionExists(int id)
        {
            return _context.Deception.Any(e => e.Deceptionid == id);
        }
    }
}
