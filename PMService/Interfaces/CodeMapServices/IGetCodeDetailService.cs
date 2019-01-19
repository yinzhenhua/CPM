using System;
using System.Collections.Generic;
using PMService.DTOs.CodeMap;

namespace PMService.Interfaces.CodeMapServices
{
    public interface IGetCodeDetailService
    {
        IEnumerable<CodeDetailDTO> GetByCategory(string category);
    }
}
