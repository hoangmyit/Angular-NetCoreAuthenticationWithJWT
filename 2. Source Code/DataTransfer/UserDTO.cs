using System;
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
    }
}
