using System;
using Domain;
using PMService.DTOs.CodeMap;
using PMService.Interfaces.CodeMapServices;
using PMRepository.IRepositories;

namespace PMService.Services.CodeMapServices
{
    public class ModifyService4CodeMap : IAddService4CodeMap
    {
        private readonly IRepository4CodeMap _codeMapRepository;

        public ModifyService4CodeMap(IRepository4CodeMap repository)
        {
            _codeMapRepository = repository;
        }

        public void AddCodeMap(CodeMap4AddDTO dto4Add)
        {
            var code = new CodeMap
            {
                Key = _codeMapRepository.GetKey(),
                CodeName = dto4Add.CodeName,
                Category = dto4Add.Category,
                ChineseName = dto4Add.ChineseName,
                Upper = dto4Add.CodeName.ToUpper(),
                Lower = dto4Add.CodeName.ToLower(),
                CreatedOn = DateTime.Now,
                Description = dto4Add.Description,
                Status = CodeStatus.Active
            };
            _codeMapRepository.Add(code);
        }
    }
}
