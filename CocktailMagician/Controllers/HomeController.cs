using CocktailMagician.Contracts;
using CocktailMagician.Domain.Services.Interfaces;
using CocktailMagician.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBarService barService;
        private readonly ICocktailService cocktailService;
        private readonly int pageSize = 3;

        public HomeController(IBarService barService, ICocktailService cocktailService)
        {
            this.barService = barService;
            this.cocktailService = cocktailService;
        }

        public async Task<IActionResult> Index()
        {
            var topRated = await this.cocktailService.GetTopRatedCoktails();
            
            return View(topRated);
        }
               

        //[HttpGet]
        //public async Task<IActionResult> Index(int? page, string barname)
        //{
        //    var bars = await this.searchService
        //        .SearchByName(barname);

        //    var pagedBars = await bars
        //        .ToPagedListAsync(page ?? 1, pageSize);

        //    return View(pagedBars);
        //}

        //[HttpGet]
        //public async Task<IActionResult> Search(int? page, string barname)
        //{
        //    var bars = await this.searchService
        //        .SearchByName(barname);

        //    var pagedBars = await bars
        //        .ToPagedListAsync(page ?? 1, pageSize);

        //    return PartialView("_BarGrid", pagedBars);
        //}

        //public async Task<IActionResult> GetTopRatedBars(int? page)
        //{
        //    var topRatedBars = await this.barService.GetTopRatedBars();
        //    var smt = await topRatedBars.ToPagedListAsync(page ?? 1, pageSize);
        //    return PartialView("_BarGrid", smt);
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        [Route("Error/{statusCode}")]
        public IActionResult Error(int? statusCode = null)
        {
            if (statusCode == null)
                statusCode = HttpContext.Response.StatusCode;

            if (statusCode.Value == 404)
            {
                return View(new Error { Message = "The page doesn't exist." });
            }
            else if (statusCode.Value == 401)
            {
                return View(new Error { Message = "User unauthorized." });
            }
            else
            {
                return View(new Error { Message = "Ooops something happened." });
            }
        }

        public IActionResult Error()
        {
            return View(new Error { Message = "Ooops something happened." });

        }
    }
}
