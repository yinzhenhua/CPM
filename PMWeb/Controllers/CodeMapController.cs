using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PMRepository;
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
        private readonly IUnitOfWork<DataContext> _context;

        public CodeMapController(IGetCategories getCategoriesService,
            IAddService4CodeMap addCategoryService,
            IUnitOfWork<DataContext> context)
        {
            _getCategoriesService = getCategoriesService;
            _addCategoryService = addCategoryService;
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var categories = _getCategoriesService.GetCategories();
            ViewData["categories"] = categories;
            return View("Index");
        }

        [HttpPost]
        public IActionResult SaveCode(CodeMapViewModel4Add item)
        {
            _addCategoryService.AddCodeMap(item);
            _context.Commit();
            return RedirectToAction("Index", item);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context?.Dispose();
        }
    }
}