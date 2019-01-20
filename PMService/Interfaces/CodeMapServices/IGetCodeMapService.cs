using System.Collections.Generic;
using PMService.ViewModels.CodeMap;

namespace PMService.Interfaces.CodeMapServices
{
    public interface IGetCodeMapService
    {
        IEnumerable<CodeMapViewModel4List> Get(int pageSize = 10, int pageIndex = 0);
    }
}