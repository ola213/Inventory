using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODELS.Entities
{
    public class Role: IdentityRole<int>
    {
        public ICollection<UserRole> UserRole { get; set; }
    }
}
