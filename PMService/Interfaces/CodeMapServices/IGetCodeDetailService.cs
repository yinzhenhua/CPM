using System;
using System.Collections.Generic;
using PMService.DTOs.CodeMap;
using PMService.Infrastructure;

namespace PMService.Interfaces.CodeMapServices
{
    public interface IGetCodeDetailService
    {
        IEnumerable<CodeDetail> GetByCategory(string category);
    }
}
