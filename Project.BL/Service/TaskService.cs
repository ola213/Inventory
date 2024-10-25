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
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUnitOfWork _unitOfWork;

         public TaskService(ITaskRepository taskRepository, IUnitOfWork unitOfWork)
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Project.MODELS.Entities.Task>> GetAllTasksAsync()
        {
            return await _taskRepository.GetAllAsync();
        }

        public async Task<Project.MODELS.Entities.Task> GetTaskByIdAsync(int id)
        {
            return await _taskRepository.GetByIdAsync(id);
        }

        public async Task CreateTaskAsync(Project.MODELS.Entities.Task task)
        {
            await _taskRepository.AddAsync(task);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateTaskAsync(Project.MODELS.Entities.Task task)
        {
            _taskRepository.Update(task);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            if (task != null)
            {
                _taskRepository.Delete(task);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<IEnumerable<Project.MODELS.Entities.Task>> GetTasksByProjectIdAsync(int projectId)
        {
            return await _taskRepository.FindAsync(t => t.ProjectId == projectId);
        }

    }
}
