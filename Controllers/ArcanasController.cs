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
    public class ArcanasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArcanasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Arcanas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Arcana.ToListAsync());
        }

        // GET: Arcanas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arcana = await _context.Arcana
                .FirstOrDefaultAsync(m => m.Arcanaid == id);
            if (arcana == null)
            {
                return NotFound();
            }

            return View(arcana);
        }

        // GET: Arcanas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Arcanas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Arcanaid,Arcanaprof")] Arcana arcana)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arcana);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(arcana);
        }

        // GET: Arcanas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arcana = await _context.Arcana.FindAsync(id);
            if (arcana == null)
            {
                return NotFound();
            }
            return View(arcana);
        }

        // POST: Arcanas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Arcanaid,Arcanaprof")] Arcana arcana)
        {
            if (id != arcana.Arcanaid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arcana);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArcanaExists(arcana.Arcanaid))
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
            return View(arcana);
        }

        // GET: Arcanas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arcana = await _context.Arcana
                .FirstOrDefaultAsync(m => m.Arcanaid == id);
            if (arcana == null)
            {
                return NotFound();
            }

            return View(arcana);
        }

        // POST: Arcanas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arcana = await _context.Arcana.FindAsync(id);
            _context.Arcana.Remove(arcana);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArcanaExists(int id)
        {
            return _context.Arcana.Any(e => e.Arcanaid == id);
        }
    }
}
