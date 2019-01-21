using System.Collections.Generic;
using PMService.ViewModels.Project;

namespace PMService.Interfaces.ProjectServices
{
    public interface IGetProjectService
    {
        IEnumerable<ProjectViewModel4List> GetProjects(int pageIndex, int pageSize);
    }
}