using System;
using System.Collections.Generic;

namespace PMService.Interfaces.CodeMapServices
{
    public interface IGetCategories
    {
        IEnumerable<string> GetCategories();
    }
}
