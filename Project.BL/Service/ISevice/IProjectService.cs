using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Service.ISevice
{
    public interface IProjectService
    {
        Task<IEnumerable<Project.MODELS.Entities.Project>> GetAllProjectsAsync();
        Task<Project.MODELS.Entities.Project> GetProjectByIdAsync(int id);
        Task CreateProjectAsync(Project.MODELS.Entities.Project project);
        Task UpdateProjectAsync(Project.MODELS.Entities.Project project);
        Task DeleteProjectAsync(int id);
        Task<float> CalculateProjectProgressAsync(int projectId);
    }
}

