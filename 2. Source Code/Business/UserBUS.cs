using Business.Interface;
using DataTransfer;
using System;
using System.Collections.Generic;

namespace Business
{
    public class UserBUS : IUserBUS
    {
        public List<Role> GetRole(int userID)
        {
            throw new NotImplementedException();
        }

        public List<Role> GetRoles()
        {
            return new List<Role>()
            {
                 new Role()
                 {
                     ID = 1, RoleName = "Admin", Description = "Admin Role"
                 },
                 new Role()
                 {
                     ID = 2, RoleName = "Manager", Description = "Manager Role"
                 },
                  new Role()
                 {
                     ID = 3, RoleName = "User", Description = "User Role"
                 }
            };
        }

        public User Login(string userName, string password)
        {
            User user = null;
            if (userName == "Admin")
            {
                user = new User();
                user.ID = 1;
                user.Username = "Admin";
                user.Password = password;
                user.Roles = new List<Role>()
                {
                    new Role()
                    {
                        ID = 1, RoleName = "Admin", Description = "Admin Role"
                    }
                };
            } 
            if (userName == "Manager")
            {
                user = new User();
                user.ID = 1;
                user.Username = "Manager";
                user.Password = password;
                user.Roles = new List<Role>()
                {
                    new Role()
                    {
                        ID = 2, RoleName = "Manager", Description = "Manager Role"
                    }
                };
            }
            if (userName == "Both")
            {
                user = new User();
                user.ID = 1;
                user.Username = "Both";
                user.Password = password;
                user.Roles = new List<Role>()
                {
                    new Role()
                    {
                        ID = 1, RoleName = "Admin", Description = "Admin Role"
                    },
                    new Role()
                    {
                        ID = 2, RoleName = "Manager", Description = "Manager Role"
                    }
                };
            }
            if (userName == "User")
            {
                user = new User();
                user.ID = 1;
                user.Username = "User";
                user.Password = password;
                user.Roles = new List<Role>()
                {
                    new Role()
                    {
                        ID = 3, RoleName = "User", Description = "User Role"
                    }
                };
            }
            return user;
        }

    }
}
