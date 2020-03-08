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
    public class InsightsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InsightsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Insights
        public async Task<IActionResult> Index()
        {
            return View(await _context.Insight.ToListAsync());
        }

        // GET: Insights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insight = await _context.Insight
                .FirstOrDefaultAsync(m => m.Insightid == id);
            if (insight == null)
            {
                return NotFound();
            }

            return View(insight);
        }

        // GET: Insights/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Insights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Insightid,Insighprof")] Insight insight)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insight);
        }

        // GET: Insights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insight = await _context.Insight.FindAsync(id);
            if (insight == null)
            {
                return NotFound();
            }
            return View(insight);
        }

        // POST: Insights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Insightid,Insighprof")] Insight insight)
        {
            if (id != insight.Insightid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsightExists(insight.Insightid))
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
            return View(insight);
        }

        // GET: Insights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insight = await _context.Insight
                .FirstOrDefaultAsync(m => m.Insightid == id);
            if (insight == null)
            {
                return NotFound();
            }

            return View(insight);
        }

        // POST: Insights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insight = await _context.Insight.FindAsync(id);
            _context.Insight.Remove(insight);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsightExists(int id)
        {
            return _context.Insight.Any(e => e.Insightid == id);
        }
    }
}
