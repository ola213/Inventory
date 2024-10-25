using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repository.IRepository
{
    public interface IProjectRepository : IRepository<Project.MODELS.Entities.Project>
    {
        Task<float> CalculateProjectProgressAsync(int projectId);

    }
}
