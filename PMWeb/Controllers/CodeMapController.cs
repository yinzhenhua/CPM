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
        private readonly IAddService4CodeMap _addCategoryService;

        public CodeMapController(IGetCategories getCategoriesService,
            IAddService4CodeMap addCategoryService)
        {
            _getCategoriesService = getCategoriesService;
            _addCategoryService = addCategoryService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var categories = _getCategoriesService.GetCategories();
            ViewData["categories"] = new SelectList(categories);
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveCode(CodeMapViewModel4Add item)
        {
            _addCategoryService.AddCodeMap(item);
            return RedirectToAction("Index", item);
        }
    }
}