using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PMService.Interfaces.CodeMapServices;
using PMService.ViewModels.CodeMap;
using PMWeb.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PMWeb.Controllers
{
    public class CodeMapController : Controller
    {
        private readonly IGetCategories _getCategoriesService;

        public CodeMapController(IGetCategories getCategoriesService)
        {
            _getCategoriesService = getCategoriesService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var categories = _getCategoriesService.GetCategories();
            ViewData["categories"] = new SelectList(categories);
            return View("Index");
        }

        [HttpPost]
        public IActionResult SaveCodeMap([FromBody]CodeMapViewModel4Add item)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", item);
            }
            var categories = _getCategoriesService.GetCategories();
            ViewData["categories"] = new SelectList(categories);
            return View("Index", item);
        }
    }
}
