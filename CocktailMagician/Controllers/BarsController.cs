using CocktailMagician.Contracts;
using CocktailMagician.Domain.Mappers;
using CocktailMagician.Domain.Services.Interfaces;
using CocktailMagician.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CocktailMagician.Controllers
{
    public class BarsController : Controller
    {
        private readonly IBarService barService;
        private readonly IUserService userService;
        private readonly IHostingEnvironment hostingEnvironment;
        public BarsController(IBarService barService, IUserService userService, IHostingEnvironment hostingEnvironment)
        {
            this.barService = barService;
            this.userService = userService;
            this.hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index(int id)
        {
            var role = this.User.FindFirstValue(ClaimTypes.Role);
            const int PageSize = 3;            
            var counter = await this.barService.ListAll(role);
            var count = counter.Count();

            var data = counter.OrderBy(x => x.Id).Skip(id * PageSize).Take(PageSize).ToList();

            this.ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);

            this.ViewBag.Page = id;

            return this.View(data);
        }

        public async Task<ActionResult> Details(int id)
        {
            var bar = await this.barService.GetBar(id);
            var reviews = await this.barService.GetBarReviews(id);

            var barDetails = new BarDetailsViewModel();
            barDetails.Bar = bar;
            barDetails.BarReviews = reviews;

            return View(barDetails);            
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
        public async Task<IActionResult> Create(BarCreateRequest bar)
        {

            if (!this.ModelState.IsValid)
            {
                return View(bar);
            }

            if (bar.Image != null)
            {
                var (extension, isValid) = GetFileExtension(bar.Image.ContentType);

                if (!isValid)
                {
                    TempData["ErrorMessage"] = "Invalid file type, please upload image!";
                    return RedirectToAction("Create", "Bars");
                }
                string destinationFolder = Path.Combine(hostingEnvironment.WebRootPath, "images/bars");
                string fileName = Guid.NewGuid().ToString() + "_" + bar.Image.FileName;
                string imagePath = Path.Combine(destinationFolder, fileName);
                bar.Image.CopyTo(new FileStream(imagePath, FileMode.Create));
                bar.ImagePath = $"/images/bars/" + fileName;
            }

           var barContract =  await this.barService.Create(bar);

            return RedirectToAction("Index", "Bars");            
        }

        private (string extension, bool isValid) GetFileExtension(string contentType)
        {
            if (contentType == "image/jpeg")
                return (".jpg", true);
            if (contentType == "image/png")
                return (".png", true);

            return (string.Empty, false);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var bar = await this.barService.GetBar(id);
            var cocktails = await barService.ListCocktails();
            ViewData["Cocktails"] = cocktails.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
            return View(bar.ToUpdateRequest());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BarUpdateRequest bar)
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

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(string input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }
            var result = await this.barService.SearchBarByName(input);
            var output = new BarSearchResult
            {
                Input = new List<Bar>(result)
            };

            return View(output);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchAddress (string input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }
            var result = await this.barService.SearchBarAddress(input);
            var output = new BarSearchResult
            {
                Input = new List<Bar>(result)
            };

            return View(output);
        }
    }
}