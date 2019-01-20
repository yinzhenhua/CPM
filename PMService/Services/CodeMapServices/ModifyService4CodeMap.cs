using System;
using Domain;
using PMService.DTOs.CodeMap;
using PMService.Interfaces.CodeMapServices;
using PMRepository.IRepositories;
using PMService.ViewModels.CodeMap;

namespace PMService.Services.CodeMapServices
{
    public class ModifyService4CodeMap : IAddService4CodeMap, IUpdateCodeStatusService
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

        public void AddCodeMap(CodeMapViewModel4Add viewModel4Add)
        {
            var code = new CodeMap
            {
                Key = _codeMapRepository.GetKey(),
                CodeName = viewModel4Add.CodeName,
                Category = viewModel4Add.Category,
                ChineseName = viewModel4Add.ChineseName,
                Upper = viewModel4Add.CodeName.ToUpper(),
                Lower = viewModel4Add.CodeName.ToLower(),
                CreatedOn = DateTime.Now,
                Description = viewModel4Add.Description,
                Status = CodeStatus.Active
            };
            _codeMapRepository.Add(code);
        }

        public void UpdateStatus(string key, CodeStatus status)
        {
            var code = _codeMapRepository.Find(key);
            code.Status = status;
            code.UpdatedOn = DateTime.Now;
            if (status == CodeStatus.InActive)
            {
                code.RemovedOn=DateTime.Now;
            }
            _codeMapRepository.Update(code);
        }
    }
}
