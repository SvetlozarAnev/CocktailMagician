using CocktailMagician.Domain.Services.Interfaces;
using CocktailMagician.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CocktailMagician.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISearchService searchService;
        private readonly IBarService barService;
        private readonly int pageSize = 3;

        public HomeController(ISearchService searchService, IBarService barService)
        {
            this.searchService = searchService;
            this.barService = barService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? page, string barname)
        {
            var bars = await this.searchService
                .SearchByName(barname);

            var pagedBars = await bars
                .ToPagedListAsync(page ?? 1, pageSize);

            return View(pagedBars);
        }

        [HttpGet]
        public async Task<IActionResult> Search(int? page, string barname)
        {
            var bars = await this.searchService
                .SearchByName(barname);

            var pagedBars = await bars
                .ToPagedListAsync(page ?? 1, pageSize);

            return PartialView("_BarGrid", pagedBars);
        }

        public async Task<IActionResult> GetTopRatedBars(int? page)
        {
            var topRatedBars = await this.barService.GetTopRatedBars();
            var smt = await topRatedBars.ToPagedListAsync(page ?? 1, pageSize);
            return PartialView("_BarGrid", smt);
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
