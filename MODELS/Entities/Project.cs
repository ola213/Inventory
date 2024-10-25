using Project.MODELS.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODELS.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public ICollection<Task> Tasks { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public float progress { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }
}
