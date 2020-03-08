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
    public class InventoryHasItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventoryHasItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InventoryHasItems
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.InventoryHasItems.Include(i => i.Inventory).Include(i => i.Item);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: InventoryHasItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryHasItems = await _context.InventoryHasItems
                .Include(i => i.Inventory)
                .Include(i => i.Item)
                .FirstOrDefaultAsync(m => m.InventoryHasItemsid == id);
            if (inventoryHasItems == null)
            {
                return NotFound();
            }

            return View(inventoryHasItems);
        }

        // GET: InventoryHasItems/Create
        public IActionResult Create()
        {
            ViewData["Inventoryid"] = new SelectList(_context.Inventory, "Inventoryid", "Inventoryid");
            ViewData["Itemid"] = new SelectList(_context.Items, "Itemsid", "Itemsid");
            return View();
        }

        // POST: InventoryHasItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InventoryHasItemsid,Inventoryid,Itemid,Active,Isattuned,Quantity")] InventoryHasItems inventoryHasItems)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventoryHasItems);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Inventoryid"] = new SelectList(_context.Inventory, "Inventoryid", "Inventoryid", inventoryHasItems.Inventoryid);
            ViewData["Itemid"] = new SelectList(_context.Items, "Itemsid", "Itemsid", inventoryHasItems.Itemid);
            return View(inventoryHasItems);
        }

        // GET: InventoryHasItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryHasItems = await _context.InventoryHasItems.FindAsync(id);
            if (inventoryHasItems == null)
            {
                return NotFound();
            }
            ViewData["Inventoryid"] = new SelectList(_context.Inventory, "Inventoryid", "Inventoryid", inventoryHasItems.Inventoryid);
            ViewData["Itemid"] = new SelectList(_context.Items, "Itemsid", "Itemsid", inventoryHasItems.Itemid);
            return View(inventoryHasItems);
        }

        // POST: InventoryHasItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("InventoryHasItemsid,Inventoryid,Itemid,Active,Isattuned,Quantity")] InventoryHasItems inventoryHasItems)
        {
            if (id != inventoryHasItems.InventoryHasItemsid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventoryHasItems);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryHasItemsExists(inventoryHasItems.InventoryHasItemsid))
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
            ViewData["Inventoryid"] = new SelectList(_context.Inventory, "Inventoryid", "Inventoryid", inventoryHasItems.Inventoryid);
            ViewData["Itemid"] = new SelectList(_context.Items, "Itemsid", "Itemsid", inventoryHasItems.Itemid);
            return View(inventoryHasItems);
        }

        // GET: InventoryHasItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryHasItems = await _context.InventoryHasItems
                .Include(i => i.Inventory)
                .Include(i => i.Item)
                .FirstOrDefaultAsync(m => m.InventoryHasItemsid == id);
            if (inventoryHasItems == null)
            {
                return NotFound();
            }

            return View(inventoryHasItems);
        }

        // POST: InventoryHasItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var inventoryHasItems = await _context.InventoryHasItems.FindAsync(id);
            _context.InventoryHasItems.Remove(inventoryHasItems);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryHasItemsExists(int? id)
        {
            return _context.InventoryHasItems.Any(e => e.InventoryHasItemsid == id);
        }
    }
}
