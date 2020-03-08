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
    public class NaturesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NaturesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Natures
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nature.ToListAsync());
        }

        // GET: Natures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nature = await _context.Nature
                .FirstOrDefaultAsync(m => m.Natureid == id);
            if (nature == null)
            {
                return NotFound();
            }

            return View(nature);
        }

        // GET: Natures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Natures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Natureid,Natureprof")] Nature nature)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nature);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nature);
        }

        // GET: Natures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nature = await _context.Nature.FindAsync(id);
            if (nature == null)
            {
                return NotFound();
            }
            return View(nature);
        }

        // POST: Natures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Natureid,Natureprof")] Nature nature)
        {
            if (id != nature.Natureid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nature);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NatureExists(nature.Natureid))
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
            return View(nature);
        }

        // GET: Natures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nature = await _context.Nature
                .FirstOrDefaultAsync(m => m.Natureid == id);
            if (nature == null)
            {
                return NotFound();
            }

            return View(nature);
        }

        // POST: Natures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nature = await _context.Nature.FindAsync(id);
            _context.Nature.Remove(nature);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NatureExists(int id)
        {
            return _context.Nature.Any(e => e.Natureid == id);
        }
    }
}
