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
        private readonly IGetCodeMapService _getCodeMapService;
        private readonly IUpdateCodeStatusService _updateCodeStatusService;
        private readonly IUnitOfWork<DataContext> _context;

        public CodeMapController(IGetCategories getCategoriesService,
            IAddService4CodeMap addCategoryService,
            IUnitOfWork<DataContext> context,
            IGetCodeMapService getCodeMapService,
            IUpdateCodeStatusService updateCodeStatusService)
        {
            _getCategoriesService = getCategoriesService;
            _addCategoryService = addCategoryService;
            _getCodeMapService = getCodeMapService;
            _updateCodeStatusService = updateCodeStatusService;
            _context = context;
        }

        public IActionResult Index()
        {
            var codeMap = _getCodeMapService.Get();
            return View("Index", codeMap);
        }
        // GET: /<controller>/
        public IActionResult CreateCode()
        {
            var categories = _getCategoriesService.GetCategories();
            ViewData["categories"] = categories;
            return View("Create");
        }

        [HttpPost]
        public IActionResult SaveCode(CodeMapViewModel4Add item)
        {
            _addCategoryService.AddCodeMap(item);
            _context.Commit();
            return RedirectToAction("Index", item);
        }

        [HttpGet]
        public IActionResult InActive(string key)
        {
            _updateCodeStatusService.UpdateStatus(key, CodeStatus.InActive);
            _context.Commit();
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult Active(string key)
        {
            _updateCodeStatusService.UpdateStatus(key,CodeStatus.Active);
            _context.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context?.Dispose();
        }
    }
}