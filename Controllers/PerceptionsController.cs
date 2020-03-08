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
    public class PerceptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PerceptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Perceptions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Perception.ToListAsync());
        }

        // GET: Perceptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perception = await _context.Perception
                .FirstOrDefaultAsync(m => m.Perceptionid == id);
            if (perception == null)
            {
                return NotFound();
            }

            return View(perception);
        }

        // GET: Perceptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Perceptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Perceptionid,Perceptionprof")] Perception perception)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perception);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(perception);
        }

        // GET: Perceptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perception = await _context.Perception.FindAsync(id);
            if (perception == null)
            {
                return NotFound();
            }
            return View(perception);
        }

        // POST: Perceptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Perceptionid,Perceptionprof")] Perception perception)
        {
            if (id != perception.Perceptionid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perception);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerceptionExists(perception.Perceptionid))
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
            return View(perception);
        }

        // GET: Perceptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perception = await _context.Perception
                .FirstOrDefaultAsync(m => m.Perceptionid == id);
            if (perception == null)
            {
                return NotFound();
            }

            return View(perception);
        }

        // POST: Perceptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var perception = await _context.Perception.FindAsync(id);
            _context.Perception.Remove(perception);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerceptionExists(int id)
        {
            return _context.Perception.Any(e => e.Perceptionid == id);
        }
    }
}
