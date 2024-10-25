using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODELS.Entities
{
    public class Contributor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
        public string Address { get; set; }

        public int UserId { get; set; }
        public  User User{ get; set; }
        public int ProjectId { get; set; }
        public Project Project{ get; set; }
    }
}
