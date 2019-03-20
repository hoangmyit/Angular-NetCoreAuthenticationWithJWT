using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
    public class UserRole
    {         
        public int ID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int RoleID { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
