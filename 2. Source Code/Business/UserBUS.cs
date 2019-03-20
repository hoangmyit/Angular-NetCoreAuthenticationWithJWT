using Business.Interface;
using DataTransfer;
using System;
using System.Collections.Generic;

namespace Business
{
    public class UserBUS : IUserBUS
    {
        public List<RoleDTO> GetRole(int userID)
        {
            throw new NotImplementedException();
        }

        public List<RoleDTO> GetRoles()
        {
            return new List<RoleDTO>()
            {
                 new RoleDTO()
                 {
                     ID = 1, RoleName = "Admin", Description = "Admin Role"
                 },
                 new RoleDTO()
                 {
                     ID = 2, RoleName = "Manager", Description = "Manager Role"
                 },
                  new RoleDTO()
                 {
                     ID = 3, RoleName = "User", Description = "User Role"
                 }
            };
        }

        public UserDTO Login(string userName, string password)
        {
            UserDTO user = null;
            if (userName == "Admin")
            {
                user = new UserDTO();
                user.ID = 1;
                user.Username = "Admin";
                user.Password = password;
                user.Roles = new List<RoleDTO>()
                {
                    new RoleDTO()
                    {
                        ID = 1, RoleName = "Admin", Description = "Admin Role"
                    }
                };
            } 
            if (userName == "Manager")
            {
                user = new UserDTO();
                user.ID = 1;
                user.Username = "Manager";
                user.Password = password;
                user.Roles = new List<RoleDTO>()
                {
                    new RoleDTO()
                    {
                        ID = 2, RoleName = "Manager", Description = "Manager Role"
                    }
                };
            }
            if (userName == "Both")
            {
                user = new UserDTO();
                user.ID = 1;
                user.Username = "Both";
                user.Password = password;
                user.Roles = new List<RoleDTO>()
                {
                    new RoleDTO()
                    {
                        ID = 1, RoleName = "Admin", Description = "Admin Role"
                    },
                    new RoleDTO()
                    {
                        ID = 2, RoleName = "Manager", Description = "Manager Role"
                    }
                };

            }
            if (userName == "User")
            {
                user = new UserDTO();
                user.ID = 1;
                user.Username = "User";
                user.Password = password;
                user.Roles = new List<RoleDTO>()
                {
                    new RoleDTO()
                    {
                        ID = 3, RoleName = "User", Description = "User Role"
                    }
                };
            }
            return user;
        }

    }
}
