using CocktailMagician.Contracts;
using CocktailMagician.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using CocktailMagician.Domain.Mappers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CocktailMagician.Controllers
{
    public class CocktailsController : Controller
    {
        private readonly ICocktailService cocktailService;
        private readonly IUserService userService;
        private readonly IIngredientService ingredientService;

        public CocktailsController(ICocktailService cocktailService, IUserService userService, IIngredientService ingredientService)
        {
            this.cocktailService = cocktailService;
            this.userService = userService;
            this.ingredientService = ingredientService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var role = this.User.FindFirstValue(ClaimTypes.Role);
            //var cocktails = await this.cocktailService.ListAll(role);
            //return View(cocktails);

            const int PageSize = 3;

            var counter = await this.cocktailService.ListAll(role);
            var count = counter.Count();

            var data = counter.OrderBy(x => x.Id).Skip(id * PageSize).Take(PageSize).ToList();

            this.ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);

            this.ViewBag.Page = id;

            return this.View(data);
        }

        public async Task<ActionResult> Details(int id)
        {
            var cocktail = await this.cocktailService.GetCocktail(id);

            return View(cocktail);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            var ingredients = await ingredientService.ListAll();
            ViewData["Ingredients"] = ingredients.Select(x => new SelectListItem(x.Name, x.Id.ToString()));

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CocktailCreateRequest cocktail)
        {
            if (!this.ModelState.IsValid)
            {
                return View(cocktail);
            }
            await this.cocktailService.Create(cocktail);

            return RedirectToAction("Index", "Cocktails");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var cocktail = await this.cocktailService.GetCocktail(id);
            var ingredients = await ingredientService.ListAll();
            ViewData["Ingredients"] = ingredients.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
            return View(cocktail.ToUpdateRequest());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CocktailUpdateRequest cocktail)
        {
            if (!this.ModelState.IsValid)
            {
                return View(cocktail);
            }

            await this.cocktailService.Update(cocktail);

            return RedirectToAction("Index", "Cocktails");
        }
        [HttpGet]
        [Authorize]
        public IActionResult Review(int id)
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Review(CocktailReview cocktailReview, int id)
        {

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.userService.AddCocktailReview(cocktailReview, id, userId);

            return RedirectToAction("Index", "Cocktails");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Toggle(int id)
        {
            await this.cocktailService.Toggle(id);

            return RedirectToAction("Index", "Cocktails");
        }

        public async Task<IActionResult> Ingredients()
        {
            var ingredients = await this.ingredientService.ListAll();
            return View(ingredients);
        }
    }
}