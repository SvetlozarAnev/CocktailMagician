using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocktailMagician.Contracts;
using CocktailMagician.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CocktailMagician.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly IIngredientService ingredientService;
        private readonly IUserService userService;

        public IngredientsController(IIngredientService ingredientService, IUserService userService)
        {
            this.ingredientService = ingredientService;
            this.userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            var ingredients = await this.ingredientService.ListAll();
            return View(ingredients);
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
        public async Task<IActionResult> Create(Ingredient ingredient)
        {
            if (!this.ModelState.IsValid)
            {
                return View(ingredient);
            }
            await this.ingredientService.Create(ingredient);

            return RedirectToAction("Index", "Ingredients");
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.ingredientService.Delete(id);
            return RedirectToAction("Index", "Ingredients"); ;
        }
    }
}