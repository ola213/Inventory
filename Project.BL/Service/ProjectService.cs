using Project.BL.Service.ISevice;
using Project.DAL.Repository.IRepository;
using Project.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Service
{
    public class ProjectService :IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Project.MODELS.Entities.Project>> GetAllProjectsAsync()
        {
            return await _projectRepository.GetAllAsync();
        }

        public async Task<Project.MODELS.Entities.Project> GetProjectByIdAsync(int id)
        {
            return await _projectRepository.GetByIdAsync(id);
        }

        public async Task CreateProjectAsync(Project.MODELS.Entities.Project project)
        {
            await _projectRepository.AddAsync(project);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateProjectAsync(Project.MODELS.Entities.Project project)
        {
            _projectRepository.Update(project);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteProjectAsync(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project != null)
            {
                _projectRepository.Delete(project);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<float> CalculateProjectProgressAsync(int projectId)
        {
            return await _projectRepository.CalculateProjectProgressAsync(projectId);
        }

    }
}
