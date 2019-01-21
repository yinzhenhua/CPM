using Domain;
using Microsoft.AspNetCore.Mvc;
using PMRepository;
using PMService.Infrastructure;
using PMService.Interfaces.CodeMapServices;
using PMService.Interfaces.ProjectServices;
using PMService.ViewModels.Project;
using Remotion.Linq.Parsing.ExpressionVisitors.TreeEvaluation;

namespace PMWeb.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IGetProjectService _getProjectService;
        private readonly IGetCodeDetailService _getCodeDetailService;
        private readonly IAddProjectService _addProjectService;

        private readonly IUnitOfWork<DataContext> _unitOfWork;

        public ProjectController(IGetProjectService getProjectService,
            IAddProjectService addProjectService,
            IUnitOfWork<DataContext> unitOfWork,
            IGetCodeDetailService getCodeDetailService)
        {
            _getProjectService = getProjectService;
            _addProjectService = addProjectService;
            _getCodeDetailService = getCodeDetailService;
            _unitOfWork = unitOfWork;
        }
        // GET
        public IActionResult Index()
        {
            var projects = _getProjectService.GetProjects(0, 10);
            return View("Projects", projects);
        }

        public IActionResult Create()
        {
            var codes = _getCodeDetailService.GetByCategory(CommonConstant.CodeCategories.ProjectState);
            ViewData["codes"] = codes;
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(ProjectViewModel4Create viewModel)
        {
            _addProjectService.AddProject(viewModel);
            _unitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _unitOfWork?.Dispose();
        }
    }
}