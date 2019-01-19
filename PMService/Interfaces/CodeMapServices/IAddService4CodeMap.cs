using System;
using PMService.DTOs.CodeMap;

namespace PMService.Interfaces.CodeMapServices
{
    public interface IAddService4CodeMap
    {
        void AddCodeMap(CodeMap4AddDTO dto4Add);
    }
}
