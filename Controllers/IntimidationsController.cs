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
    public class IntimidationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IntimidationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Intimidations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Intimidation.ToListAsync());
        }

        // GET: Intimidations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intimidation = await _context.Intimidation
                .FirstOrDefaultAsync(m => m.Intimidationid == id);
            if (intimidation == null)
            {
                return NotFound();
            }

            return View(intimidation);
        }

        // GET: Intimidations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Intimidations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Intimidationid,Intimidationprof")] Intimidation intimidation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(intimidation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(intimidation);
        }

        // GET: Intimidations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intimidation = await _context.Intimidation.FindAsync(id);
            if (intimidation == null)
            {
                return NotFound();
            }
            return View(intimidation);
        }

        // POST: Intimidations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Intimidationid,Intimidationprof")] Intimidation intimidation)
        {
            if (id != intimidation.Intimidationid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(intimidation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IntimidationExists(intimidation.Intimidationid))
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
            return View(intimidation);
        }

        // GET: Intimidations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intimidation = await _context.Intimidation
                .FirstOrDefaultAsync(m => m.Intimidationid == id);
            if (intimidation == null)
            {
                return NotFound();
            }

            return View(intimidation);
        }

        // POST: Intimidations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var intimidation = await _context.Intimidation.FindAsync(id);
            _context.Intimidation.Remove(intimidation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IntimidationExists(int id)
        {
            return _context.Intimidation.Any(e => e.Intimidationid == id);
        }
    }
}
