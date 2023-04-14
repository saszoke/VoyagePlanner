using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using VoyagePlanner.Data;
using VoyagePlanner.Models;

namespace VoyagePlanner.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VoyagePlannerContext _context;

        public HomeController(ILogger<HomeController> logger, VoyagePlannerContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //IEnumerable<Allowance> list = await _context.Allowances.ToListAsync()
            //var person = new Person();
            return View(await _context.Allowances.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}