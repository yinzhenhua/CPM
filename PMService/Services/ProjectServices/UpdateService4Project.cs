using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using PMRepository.IRepositories;
using PMService.Interfaces.ProjectServices;
using PMService.ViewModels.Project;

namespace PMService.Services.ProjectServices
{
    public class UpdateService4Project:IAddProjectService
    {
        private readonly IRepository4CodeMap _codeMapRepository;
        private readonly IRepository4SecurityKey _securityKeyRepository;
        private readonly IRepository4Project _projectRepository;

        public UpdateService4Project(IRepository4Project projectRepository,
            IRepository4CodeMap codeMapRepository,
            IRepository4SecurityKey securityKeyRepository)
        {
            _projectRepository = projectRepository;
            _codeMapRepository = codeMapRepository;
            _securityKeyRepository = securityKeyRepository;
        }

        public void AddProject(ProjectViewModel4Create viewModel)
        {
            var codeMap = _codeMapRepository.Find(viewModel.ProjectState);
            var securityKey = new SecurityKey
            {
                SecurityCode = BitConverter.ToString(Guid.NewGuid().ToByteArray())
                    .Replace("-", string.Empty).ToUpper(),
                Key = _securityKeyRepository.GetKey()
            };
            _securityKeyRepository.Add(securityKey);
            var project = new Project
            {
                Key = _projectRepository.GetKey(),
                Name = viewModel.ProjectName,
                ProjectState = codeMap,
                SecurityKey = securityKey
            };
            _projectRepository.Add(project);
        }
    }
}