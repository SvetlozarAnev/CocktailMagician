using CocktailMagician.Contracts;
using CocktailMagician.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CocktailMagician.Controllers
{
    public class CocktailsController : Controller
    {
        private readonly ICocktailService cocktailService;
        public CocktailsController(ICocktailService cocktailService)
        {
            this.cocktailService = cocktailService;
        }

        public async Task<IActionResult> Index()
        {
            var role = this.User.FindFirstValue(ClaimTypes.Role);
            var cocktails = await this.cocktailService.ListAll(role);
            return View(cocktails);
        }

        public async Task<ActionResult> Details(int id)
        {
            var cocktail = await this.cocktailService.GetCocktail(id);
            if (cocktail == null)
            {
                throw new ArgumentException("No such Bar!");
            }
            return View(cocktail);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cocktail cocktail)
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

            return View(cocktail);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Cocktail cocktail)
        {
            if (!this.ModelState.IsValid)
            {
                return View(cocktail);
            }

            await this.cocktailService.Update(cocktail);

            return RedirectToAction("Index", "Cocktails");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Toggle(int id)
        {
            await this.cocktailService.Toggle(id);

            return RedirectToAction("Index", "Cocktails");
        }
    }
}