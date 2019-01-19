using System;
using System.Linq;
using System.Collections.Generic;
using PMRepository.IRepositories;
using PMService.Interfaces.CodeMapServices;
using PMService.DTOs.CodeMap;

namespace PMService.Services.CodeMapServices
{
    public class FetchService4CodeMap:IGetCategories, IGetCodeDetailService
    {
        private readonly IRepository4CodeMap _codeMapRepository;

        public FetchService4CodeMap(IRepository4CodeMap repository)
        {
            _codeMapRepository = repository;
        }

        public IEnumerable<CodeDetailDTO> GetByCategory(string category)
        {
            var queryable = _codeMapRepository.GetQueryable(x => x.Category == category && x.Status == Domain.CodeStatus.Active)
                                              .Select(x => new CodeDetailDTO
                                              {
                                                  Code = x.Code,
                                                  CodeName = x.CodeName
                                              }).ToList();
            return queryable;

        }

        public IEnumerable<string> GetCategories()
        {
            var queryable = _codeMapRepository.GetQueryable()
                                              .Select(x => x.Category)
                                              .Distinct<string>();
            return queryable;
        }
    }
}
