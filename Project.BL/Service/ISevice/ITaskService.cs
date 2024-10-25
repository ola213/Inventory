using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Service.ISevice
{
    public interface ITaskService
    {
        Task<IEnumerable<Project.MODELS.Entities.Task>> GetAllTasksAsync();
        Task<Project.MODELS.Entities.Task> GetTaskByIdAsync(int id);
        Task CreateTaskAsync(Project.MODELS.Entities.Task task);
        Task UpdateTaskAsync(Project.MODELS.Entities.Task task);
        Task DeleteTaskAsync(int id);
        Task<IEnumerable<Project.MODELS.Entities.Task>> GetTasksByProjectIdAsync(int projectId);

    }
}

