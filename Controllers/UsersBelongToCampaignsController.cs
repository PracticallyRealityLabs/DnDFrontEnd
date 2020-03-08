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
    public class UsersBelongToCampaignsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersBelongToCampaignsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UsersBelongToCampaigns
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UsersBelongToCampaign.Include(u => u.Campaign).Include(u => u.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UsersBelongToCampaigns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersBelongToCampaign = await _context.UsersBelongToCampaign
                .Include(u => u.Campaign)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UsersBelongToCampaignid == id);
            if (usersBelongToCampaign == null)
            {
                return NotFound();
            }

            return View(usersBelongToCampaign);
        }

        // GET: UsersBelongToCampaigns/Create
        public IActionResult Create()
        {
            ViewData["CampaignId"] = new SelectList(_context.Campaign, "CampaignId", "CampaignId");
            ViewData["UserId"] = new SelectList(_context.Users, "UsersId", "UsersId");
            return View();
        }

        // POST: UsersBelongToCampaigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsersBelongToCampaignid,CampaignId,UserId,Role")] UsersBelongToCampaign usersBelongToCampaign)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usersBelongToCampaign);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CampaignId"] = new SelectList(_context.Campaign, "CampaignId", "CampaignId", usersBelongToCampaign.CampaignId);
            ViewData["UserId"] = new SelectList(_context.Users, "UsersId", "UsersId", usersBelongToCampaign.UserId);
            return View(usersBelongToCampaign);
        }

        // GET: UsersBelongToCampaigns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersBelongToCampaign = await _context.UsersBelongToCampaign.FindAsync(id);
            if (usersBelongToCampaign == null)
            {
                return NotFound();
            }
            ViewData["CampaignId"] = new SelectList(_context.Campaign, "CampaignId", "CampaignId", usersBelongToCampaign.CampaignId);
            ViewData["UserId"] = new SelectList(_context.Users, "UsersId", "UsersId", usersBelongToCampaign.UserId);
            return View(usersBelongToCampaign);
        }

        // POST: UsersBelongToCampaigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("UsersBelongToCampaignid,CampaignId,UserId,Role")] UsersBelongToCampaign usersBelongToCampaign)
        {
            if (id != usersBelongToCampaign.UsersBelongToCampaignid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usersBelongToCampaign);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersBelongToCampaignExists(usersBelongToCampaign.UsersBelongToCampaignid))
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
            ViewData["CampaignId"] = new SelectList(_context.Campaign, "CampaignId", "CampaignId", usersBelongToCampaign.CampaignId);
            ViewData["UserId"] = new SelectList(_context.Users, "UsersId", "UsersId", usersBelongToCampaign.UserId);
            return View(usersBelongToCampaign);
        }

        // GET: UsersBelongToCampaigns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usersBelongToCampaign = await _context.UsersBelongToCampaign
                .Include(u => u.Campaign)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UsersBelongToCampaignid == id);
            if (usersBelongToCampaign == null)
            {
                return NotFound();
            }

            return View(usersBelongToCampaign);
        }

        // POST: UsersBelongToCampaigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var usersBelongToCampaign = await _context.UsersBelongToCampaign.FindAsync(id);
            _context.UsersBelongToCampaign.Remove(usersBelongToCampaign);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersBelongToCampaignExists(int? id)
        {
            return _context.UsersBelongToCampaign.Any(e => e.UsersBelongToCampaignid == id);
        }
    }
}
