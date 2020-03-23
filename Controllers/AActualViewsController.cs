using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DnDFrontEnd.Controllers
{
    public class AActualViewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}