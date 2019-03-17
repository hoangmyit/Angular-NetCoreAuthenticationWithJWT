using System;
using System.Collections.Generic;

namespace DataTransfer
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Role> Roles { get; set; }
    }
}
