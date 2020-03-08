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
    public class SurvivalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SurvivalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Survivals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Survival.ToListAsync());
        }

        // GET: Survivals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var survival = await _context.Survival
                .FirstOrDefaultAsync(m => m.Survivalid == id);
            if (survival == null)
            {
                return NotFound();
            }

            return View(survival);
        }

        // GET: Survivals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Survivals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Survivalid,Survivalprof")] Survival survival)
        {
            if (ModelState.IsValid)
            {
                _context.Add(survival);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(survival);
        }

        // GET: Survivals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var survival = await _context.Survival.FindAsync(id);
            if (survival == null)
            {
                return NotFound();
            }
            return View(survival);
        }

        // POST: Survivals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Survivalid,Survivalprof")] Survival survival)
        {
            if (id != survival.Survivalid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(survival);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurvivalExists(survival.Survivalid))
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
            return View(survival);
        }

        // GET: Survivals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var survival = await _context.Survival
                .FirstOrDefaultAsync(m => m.Survivalid == id);
            if (survival == null)
            {
                return NotFound();
            }

            return View(survival);
        }

        // POST: Survivals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var survival = await _context.Survival.FindAsync(id);
            _context.Survival.Remove(survival);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SurvivalExists(int id)
        {
            return _context.Survival.Any(e => e.Survivalid == id);
        }
    }
}
