using System;
using System.Linq;
using System.Collections.Generic;
using Domain;
using PMRepository.IRepositories;
using PMService.Interfaces.CodeMapServices;
using PMService.DTOs.CodeMap;
using PMService.Infrastructure;
using PMService.ViewModels.CodeMap;

namespace PMService.Services.CodeMapServices
{
    public class FetchService4CodeMap:IGetCategories, IGetCodeDetailService,IGetCodeMapService
    {
        private readonly IRepository4CodeMap _codeMapRepository;

        public FetchService4CodeMap(IRepository4CodeMap repository)
        {
            _codeMapRepository = repository;
        }

        public IEnumerable<CodeDetail> GetByCategory(string category)
        {
            var queryable = _codeMapRepository.GetQueryable(x => x.Category == category && x.Status == Domain.CodeStatus.Active)
                                              .Select(x => new CodeDetail
                                              {
                                                  CodeKey = x.Key,
                                                  CodeName = x.ChineseName
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

        public IEnumerable<CodeMapViewModel4List> Get(int pageSize = 10, int pageIndex = 0)
        {
            var result = _codeMapRepository.GetQueryable()
                .Select(x => new CodeMapViewModel4List()
                {
                    CodeKey = x.Key,
                    CodeName = x.CodeName,
                    ChineseName = x.ChineseName,
                    Description = x.Description,
                    Status = x.Status== CodeStatus.Active?"正常":"冻结"
                })
                .Skip(pageSize*pageIndex)
                .Take(pageSize)
                .ToList();
            return result;
        }
    }
}
