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

        public HomeController(IBarService barService, ICocktailService cocktailService)
        {
            this.barService = barService;
            this.cocktailService = cocktailService;
        }

        public async Task<IActionResult> Index()
        {
            var topRatedBars = await this.barService.GetTopRatedBars();
            var topRatedCocktails = await this.cocktailService.GetTopRatedCoktails();

            var topRatedPage = new TopRatedViewModel();
            topRatedPage.TopRatedBars = topRatedBars;
            topRatedPage.TopRatedCocktails = topRatedCocktails;
            
            return View(topRatedPage);
        }              

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
