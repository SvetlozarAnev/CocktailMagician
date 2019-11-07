using CocktailMagician.Contracts;
using CocktailMagician.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CocktailMagician.Controllers
{
    public class BarsController : Controller
    {
        private readonly IBarService barService;
        public BarsController(IBarService barService)
        {
            this.barService = barService;
        }

        public async Task<IActionResult> Index()
        {
            var bars = await this.barService.ListAll();
            return View(bars);
        }

        public async Task<ActionResult> Details(int id)
        {
            var bar = await this.barService.Get(id);
            if (bar == null)
            {
                throw new ArgumentException("No such Bar!");
            }
            return View(bar);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
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
        public async Task<IActionResult> Edit(int id)
        {
            var bar = await this.barService.Get(id);

            return View(bar);
        }

        [HttpPost]
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

        public async Task<IActionResult> Toggle(int id)
        {
            await this.barService.Toggle(id);

            return RedirectToAction("Index", "Bars");
        }
    }
}