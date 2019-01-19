using System;
using Domain;
using Microsoft.AspNetCore.Mvc;
using PMRepository;
using PMService.DTOs.CodeMap;
using PMService.Interfaces.CodeMapServices;

namespace PMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeMapController: ControllerBase,IDisposable
    {
        private readonly IAddService4CodeMap _codeMapService;
        private readonly IUnitOfWork<DataContext> _context;
        private readonly IGetCategories _getCategoryService;
        private readonly IGetCodeDetailService _getCodeDetailService;

        public CodeMapController(IAddService4CodeMap codeMapService, 
                                 IUnitOfWork<DataContext> unitOfWork,
                                IGetCategories getCategoryService,
                                 IGetCodeDetailService getCodeDetailService)
        {
            _codeMapService = codeMapService;
            _getCategoryService = getCategoryService;
            _getCodeDetailService = getCodeDetailService;
            _context = unitOfWork;
        }

        public ObjectResult Post(CodeMap4AddDTO item)
        {
            _codeMapService.AddCodeMap(item);
            _context.Commit();
            return new ObjectResult("OK");
        }

        [HttpGet]
        public ObjectResult Get()
        {
            return new ObjectResult(_getCategoryService.GetCategories());
        }

        [HttpGet("{category}")]
        public ObjectResult Get(string category)
        {
            return new ObjectResult(_getCodeDetailService.GetByCategory(category));
        }


        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
