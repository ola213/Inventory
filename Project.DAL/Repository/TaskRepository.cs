using Microsoft.EntityFrameworkCore;
using Project.DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repository
{
    public class TaskRepository : Repository<Project.MODELS.Entities.Task>, ITaskRepository
    {
        public TaskRepository(DbContext context) : base(context)
        {
        }
    }
}
