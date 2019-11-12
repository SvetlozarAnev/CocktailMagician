using CocktailMagician.Contracts;
using CocktailMagician.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace CocktailMagician.Controllers
{
    public class BarsController : Controller
    {
        private readonly IBarService barService;
        private readonly IUserService userService;
        public BarsController(IBarService barService, IUserService userService)
        {
            this.barService = barService;
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var role = this.User.FindFirstValue(ClaimTypes.Role);
            var bars = await this.barService.ListAll(role);
            return View(bars);
        }

        public async Task<ActionResult> Details(int id)
        {
            var bar = await this.barService.GetBar(id);
           
            return View(bar);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            var cocktails = await barService.ListCocktails();
            ViewData["Cocktails"] = cocktails.Select(x => new SelectListItem(x.Name, x.Id.ToString()));

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Bar bar)
        {
            if (!this.ModelState.IsValid)
            {
                return View(bar);
            }
            await this.barService.Create(bar);

            return RedirectToAction("Index", "Bars");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var bar = await this.barService.GetBar(id);
            var cocktails = await barService.ListCocktails();
            ViewData["Cocktails"] = cocktails.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
            return View(bar);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Bar bar)
        {
            if (!this.ModelState.IsValid)
            {
                return View(bar);
            }

            await this.barService.Update(bar);

            return RedirectToAction("Index", "Bars");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Review(int id)
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Review(BarReview barReview, int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.userService.AddBarReview(barReview, id, userId);

            return RedirectToAction("Index", "Bars");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Toggle(int id)
        {
            await this.barService.Toggle(id);

            return RedirectToAction("Index", "Bars");
        }
    }
}