using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransfer
{
    public class RoleDTO
    {
        public int ID { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public RoleDTO()
        {

        }
        public RoleDTO(Role role)
        {
            ID = role.ID;
            RoleName = role.Name;
            Description = role.Description;
        }
    }
}
