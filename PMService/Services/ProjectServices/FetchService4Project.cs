using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using PMRepository.IRepositories;
using PMService.Interfaces.ProjectServices;
using PMService.ViewModels.Project;

namespace PMService.Services.ProjectServices
{
    public class FetchService4Project : IGetProjectService
    {
        private readonly IRepository4Project _projectRepository;

        public FetchService4Project(IRepository4Project projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public IEnumerable<ProjectViewModel4List> GetProjects(int pageIndex, int pageSize)
        {
            var projects = _projectRepository.GetQueryable()
                .Select(x => new ProjectViewModel4List
                {
                    ProjectKey = x.Key,
                    ProjectName = x.Name,
                    ProjectState = x.ProjectState.ChineseName
                })
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();
            return projects;
        }
    }
}