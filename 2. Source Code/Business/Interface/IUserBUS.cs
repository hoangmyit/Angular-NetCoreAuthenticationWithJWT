using DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interface
{
    public interface IUserBUS
    {
        User Login(string userName, string password);
        List<Role> GetRole(int userID);
        List<Role> GetRoles();
    }
}
