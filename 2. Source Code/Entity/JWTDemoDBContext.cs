
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
            builder.Entity<UserRole>().HasOne<User>(u => u.User).WithMany(ur => ur.UserRole).HasForeignKey(x => x.UserID);
            builder.Entity<UserRole>().HasOne<Role>(u => u.Role).WithMany(r => r.UserRole).HasForeignKey(x => x.RoleID);
            builder.Entity<Role>().HasData(
                new Role
                {
                    ID = 1,
                    Name = "Admin",
                    Description = "Admin Role"
                },
                new Role
                {
                    ID = 2,
                    Name = "Manager",
                    Description = "Manager Role"
                },
                new Role
                {
                    ID = 3,
                    Name = "User",
                    Description = "User Role"
                }
            );
            builder.Entity<User>().HasData(
                new User
                {
                    ID = 1,
                    Username = "Admin",
                    Password = "123"
                },
                new User
                {
                    ID = 2,
                    Username = "Manager",
                    Password = "123"
                },
                new User
                {
                    ID = 3,
                    Username = "User",
                    Password = "123"
                },
                new User
                {
                    ID = 4,
                    Username = "Both",
                    Password = "123"
                }

            );
            builder.Entity<UserRole>().HasData(
                new UserRole
                {
                    ID = 1,
                    UserID = 1,
                    RoleID = 1
                },
                new UserRole
                {
                    ID = 2,
                    UserID = 2,
                    RoleID = 2
                },
                new UserRole
                {
                    ID = 3,
                    UserID = 3,
                    RoleID = 3
                },
                new UserRole
                {
                    ID = 4,
                    UserID = 4,
                    RoleID = 1
                },
                new UserRole
                {
                    ID = 5,
                    UserID = 4,
                    RoleID = 2
                }

            );
        }
    }
}
