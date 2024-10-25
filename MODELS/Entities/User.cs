using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODELS.Entities
{
    public class User :IdentityUser<int>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegisteredDate { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;    // Auto-generated

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Project> projects { get; set; }
        public ICollection<UserRole> usersRoles { get; set; }
    }
}
