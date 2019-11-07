using CocktailMagician.Contracts;
using CocktailMagician.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
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
            var role = this.User.FindFirstValue(ClaimTypes.Role);
            var bars = await this.barService.ListAll(role);
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
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
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
            var bar = await this.barService.Get(id);

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

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Toggle(int id)
        {
            await this.barService.Toggle(id);

            return RedirectToAction("Index", "Bars");
        }
    }
}