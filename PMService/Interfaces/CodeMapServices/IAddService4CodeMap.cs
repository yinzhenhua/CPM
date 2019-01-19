using System;
using PMService.DTOs.CodeMap;
using PMService.ViewModels.CodeMap;

namespace PMService.Interfaces.CodeMapServices
{
    public interface IAddService4CodeMap
    {
        void AddCodeMap(CodeMap4AddDTO dto4Add);

        void AddCodeMap(CodeMapViewModel4Add viewModel4Add);
    }
}
