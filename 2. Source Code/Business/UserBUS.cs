using Business.Interface;
using DataAccess;
using DataAccess.Interface;
using DataTransfer;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class UserBUS : IUserBUS
    {
        private readonly IBaseDAO<User> userDAO;
        public UserBUS(IBaseDAO<User> userDAO)
        {
            this.userDAO = userDAO;
        }
        public List<RoleDTO> GetRole(int userID)
        {
            return userDAO.Get(userID).UserRoles.Select(x => new RoleDTO(x.Role)).ToList();
        }       

        public UserDTO Login(string userName, string password)
        {
            UserDTO user = null;
            var result = userDAO.GetAll().SingleOrDefault(x => x.Username == userName);
            if (result != null && result.Password == password)
            {
                user = new UserDTO(result);
            }
            return user;
        }

    }
}
