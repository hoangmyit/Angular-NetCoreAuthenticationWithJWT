using DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interface
{
    public interface IUserBUS
    {
        UserDTO Login(string userName, string password);
        List<RoleDTO> GetRole(int userID);
        List<RoleDTO> GetRoles();
    }
}
