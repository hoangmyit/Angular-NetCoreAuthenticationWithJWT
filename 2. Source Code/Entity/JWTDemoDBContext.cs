
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class JWTDemoDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public JWTDemoDbContext(DbContextOptions<JWTDemoDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Role>().HasIndex(r => r.Name).IsUnique();
            builder.Entity<UserRole>().HasKey(x => new { x.UserID, x.RoleID});
            builder.Entity<User>().HasMany(ur => ur.UserRoles).WithOne(u => u.User).IsRequired().HasForeignKey(ur => ur.UserID);
            builder.Entity<Role>().HasMany(ur => ur.UserRoles).WithOne(r => r.Role).IsRequired().HasForeignKey(ur => ur.RoleID);
            List<Role> roles = new List<Role>();
            roles.Add(new Role
            {
                ID = 1,
                Name = "Admin",
                Description = "Admin Role"
            });
            roles.Add(
                new Role
                {
                    ID = 2,
                    Name = "Manager",
                    Description = "Manager Role"
                });
               roles.Add( new Role
                {
                    ID = 3,
                    Name = "User",
                    Description = "User Role"
                });
            List<User> users = new List<User>();
            users.Add(new User
            {
                ID = 1,
                Username = "Admin",
                Password = "123"
            });
            users.Add(new User
                {
                    ID = 2,
                    Username = "Manager",
                    Password = "123"
                });
            users.Add(new User
            {
                ID = 3,
                Username = "User",
                Password = "123"
            });
            users.Add(new User
            {
                ID = 4,
                Username = "Both",
                Password = "123"
            });
            List<UserRole> userRoles = new List<UserRole>();
            userRoles.Add(new UserRole
            {
                ID = 1,
                UserID = 1,
                RoleID = 1
            });
            userRoles.Add(new UserRole
            {
                ID = 2,
                UserID = 2,
                RoleID = 2
            });
            userRoles.Add(new UserRole
            {
                ID = 3,
                UserID = 3,
                RoleID = 3
            });
            userRoles.Add(new UserRole
            {
                ID = 4,
                UserID = 4,
                RoleID = 1
            });
            userRoles.Add(new UserRole
            {
                ID = 5,
                UserID = 4,
                RoleID = 2
            });                     
            builder.Entity<Role>().HasData(roles);
            builder.Entity<User>().HasData(users);
            builder.Entity<UserRole>().HasData(userRoles);
            base.OnModelCreating(builder);
        }
    }
}
