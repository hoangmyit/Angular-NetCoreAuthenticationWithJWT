using Entity;
using System.Linq;
using System.Collections.Generic;

namespace DataTransfer
{
    public class UserDTO
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public List<RoleDTO> Roles { get; set; }

        public UserDTO()
        {

        }
        public UserDTO(User user)
        {
            ID = user.ID;
            Username = user.Username;
            Password = user.Password;
            Roles = user.UserRoles.Select(x => new RoleDTO(x.Role))?.ToList();
        }
    }
}
