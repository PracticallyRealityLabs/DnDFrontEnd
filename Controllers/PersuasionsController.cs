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
    public class PersuasionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersuasionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Persuasions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Persuasion.ToListAsync());
        }

        // GET: Persuasions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persuasion = await _context.Persuasion
                .FirstOrDefaultAsync(m => m.Persuasionid == id);
            if (persuasion == null)
            {
                return NotFound();
            }

            return View(persuasion);
        }

        // GET: Persuasions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Persuasions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Persuasionid,Persausionprof")] Persuasion persuasion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persuasion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(persuasion);
        }

        // GET: Persuasions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persuasion = await _context.Persuasion.FindAsync(id);
            if (persuasion == null)
            {
                return NotFound();
            }
            return View(persuasion);
        }

        // POST: Persuasions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Persuasionid,Persausionprof")] Persuasion persuasion)
        {
            if (id != persuasion.Persuasionid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persuasion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersuasionExists(persuasion.Persuasionid))
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
            return View(persuasion);
        }

        // GET: Persuasions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persuasion = await _context.Persuasion
                .FirstOrDefaultAsync(m => m.Persuasionid == id);
            if (persuasion == null)
            {
                return NotFound();
            }

            return View(persuasion);
        }

        // POST: Persuasions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var persuasion = await _context.Persuasion.FindAsync(id);
            _context.Persuasion.Remove(persuasion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersuasionExists(int id)
        {
            return _context.Persuasion.Any(e => e.Persuasionid == id);
        }
    }
}
