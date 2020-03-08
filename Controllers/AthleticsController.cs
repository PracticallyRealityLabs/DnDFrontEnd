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
    public class AthleticsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AthleticsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Athletics
        public async Task<IActionResult> Index()
        {
            return View(await _context.Athletics.ToListAsync());
        }

        // GET: Athletics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var athletics = await _context.Athletics
                .FirstOrDefaultAsync(m => m.Athleticsid == id);
            if (athletics == null)
            {
                return NotFound();
            }

            return View(athletics);
        }

        // GET: Athletics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Athletics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Athleticsid,Athleticsproficiency")] Athletics athletics)
        {
            if (ModelState.IsValid)
            {
                _context.Add(athletics);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(athletics);
        }

        // GET: Athletics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var athletics = await _context.Athletics.FindAsync(id);
            if (athletics == null)
            {
                return NotFound();
            }
            return View(athletics);
        }

        // POST: Athletics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Athleticsid,Athleticsproficiency")] Athletics athletics)
        {
            if (id != athletics.Athleticsid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(athletics);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AthleticsExists(athletics.Athleticsid))
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
            return View(athletics);
        }

        // GET: Athletics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var athletics = await _context.Athletics
                .FirstOrDefaultAsync(m => m.Athleticsid == id);
            if (athletics == null)
            {
                return NotFound();
            }

            return View(athletics);
        }

        // POST: Athletics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var athletics = await _context.Athletics.FindAsync(id);
            _context.Athletics.Remove(athletics);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AthleticsExists(int id)
        {
            return _context.Athletics.Any(e => e.Athleticsid == id);
        }
    }
}
