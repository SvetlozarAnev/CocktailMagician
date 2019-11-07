using CocktailMagician.Contracts;
using CocktailMagician.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
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
            var cocktails = await this.cocktailService.ListAll();
            return View(cocktails);
        }

        public async Task<ActionResult> Details(int id)
        {
            var cocktail = await this.cocktailService.Get(id);
            if (cocktail == null)
            {
                throw new ArgumentException("No such Bar!");
            }
            return View(cocktail);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
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
        public async Task<IActionResult> Edit(int id)
        {
            var cocktail = await this.cocktailService.Get(id);

            return View(cocktail);
        }

        [HttpPost]
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

        public async Task<IActionResult> Toggle(int id)
        {
            await this.cocktailService.Toggle(id);

            return RedirectToAction("Index", "Cocktails");
        }
    }
}