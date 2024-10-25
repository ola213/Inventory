using Project.MODELS.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODELS.Entities
{
    public class Task
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Titl { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        public DateTime? DueDate { get; set; } 
        public StatusTask Status {  get; set; }
        public PriorityTask Priority { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

}

