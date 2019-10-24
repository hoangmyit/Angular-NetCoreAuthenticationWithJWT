using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{
    public class Role
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
