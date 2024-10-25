using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODELS.Entities
{
    public class Assignment
    {
        public int UserId   { get; set; }
        public User User { get; set; }
        public Task Task { get; set; }
        public int TaskId { get; set; }
    }
}
