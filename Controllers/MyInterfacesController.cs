 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
 using DnDFrontEnd.Models;
 using DnDFrontEnd.ViewModels;

 namespace DnDFrontEnd.Controllers
{
    public class MyInterfacesController : Controller
    {
        public async Task<IActionResult> UserCampaigns()
        {
            var viewModel = new UserCampaignViewModel
            {
                
            };

            return View();
        }

        public async Task<IActionResult> DmPage()
        {
            var viewModel = new UserCampaignViewModel
            {

            };

            return View();
        }
        public async Task<IActionResult> PlayerSheet()
        {
            var viewModel = new UserCampaignViewModel
            {

            };

            return View();
        }
        public IActionResult CreateCampaign()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCampaign([Bind("UsersId,UserName,UsersEmail")] Users users)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction(nameof(CreateCampaign));
            }
            return View(users);
        }

    }
}