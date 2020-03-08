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
    public class StealthsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StealthsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Stealths
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stealth.ToListAsync());
        }

        // GET: Stealths/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stealth = await _context.Stealth
                .FirstOrDefaultAsync(m => m.Stealthid == id);
            if (stealth == null)
            {
                return NotFound();
            }

            return View(stealth);
        }

        // GET: Stealths/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stealths/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Stealthid,Stealthprof")] Stealth stealth)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stealth);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stealth);
        }

        // GET: Stealths/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stealth = await _context.Stealth.FindAsync(id);
            if (stealth == null)
            {
                return NotFound();
            }
            return View(stealth);
        }

        // POST: Stealths/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Stealthid,Stealthprof")] Stealth stealth)
        {
            if (id != stealth.Stealthid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stealth);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StealthExists(stealth.Stealthid))
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
            return View(stealth);
        }

        // GET: Stealths/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stealth = await _context.Stealth
                .FirstOrDefaultAsync(m => m.Stealthid == id);
            if (stealth == null)
            {
                return NotFound();
            }

            return View(stealth);
        }

        // POST: Stealths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stealth = await _context.Stealth.FindAsync(id);
            _context.Stealth.Remove(stealth);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StealthExists(int id)
        {
            return _context.Stealth.Any(e => e.Stealthid == id);
        }
    }
}
