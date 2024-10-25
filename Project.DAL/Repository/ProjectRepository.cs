using Microsoft.EntityFrameworkCore;
using Project.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repository
{
    public class ProjectRepository : Repository<Project.MODELS.Entities.Project>, IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // Method to calculate the progress of a project
        public async Task<float> CalculateProjectProgressAsync(int projectId)
        {
            var project = await _context.Projects
                .Include(p => p.Tasks)
                .FirstOrDefaultAsync(p => p.Id == projectId);

            if (project == null || !project.Tasks.Any())
                return 0;

            var completedTasks = project.Tasks.Count(t => t.Status == Project.MODELS.Enums.StatusTask.Done);
            return (float)completedTasks / project.Tasks.Count() * 100;
        }

    }
}
