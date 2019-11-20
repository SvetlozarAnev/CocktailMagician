using CocktailMagician.Contracts;
using CocktailMagician.Domain.Mappers;
using CocktailMagician.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System;


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

        public async Task<IActionResult> Index(int id)
        {
            var role = this.User.FindFirstValue(ClaimTypes.Role);
            //var bars = await this.barService.ListAll(role);
            //return View(bars);

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
        public async Task<IActionResult> Create(BarCreateRequest bar)
        {
            //save image to wwwroot, method in image Provider to return path, get the path and assign to bar
            //check what is the file type for saving the image

            if (!this.ModelState.IsValid)
            {
                return View(bar);
            }

            // get stream

            // create file /wwwroot/images/bar/+newguid+GetFileExtension()
          //  bar.Image.CopyToAsync
          //      bar.Image.ContentType

            await this.barService.Create(bar);

            return RedirectToAction("Index", "Bars");
        }

        private string GetFileExtension(string contentType)
        {
            if (contentType == "image/jpeg")
                return ".jpg";
            if (contentType == "image/png")
                return ".png";

            throw new System.Exception("message");
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
    }
}