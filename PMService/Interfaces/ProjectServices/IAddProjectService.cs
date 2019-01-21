using PMService.ViewModels.Project;

namespace PMService.Interfaces.ProjectServices
{
    public interface IAddProjectService
    {
        /// <summary>
        /// 新增项目信息
        /// </summary>
        /// <param name="viewModel">项目信息详情</param>
        void AddProject(ProjectViewModel4Create viewModel);
    }
}