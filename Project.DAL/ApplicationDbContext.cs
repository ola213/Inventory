using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.MODELS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int,
    IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
    IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Define DbSets for your other entities
        public DbSet<Project.MODELS.Entities.Project> Projects { get; set; }
        public DbSet<Project.MODELS.Entities.Task> TaskItems { get; set; }

        // Configure entity relationships and constraints
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<User>().ToTable("Users");
            builder.Entity<UserRole>().ToTable("UserRole");
            builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");



            builder.Entity<User>()
                   .HasMany(ur => ur.usersRoles)
                   .WithOne(u => u.User)
                   .HasForeignKey(ur => ur.UserId)
                   .IsRequired();

            builder.Entity<Role>()
                .HasMany(ur => ur.UserRole)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();




        }
    }
}


