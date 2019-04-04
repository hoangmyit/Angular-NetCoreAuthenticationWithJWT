using DataAccess.Interface;
using Entity;
using System;

namespace DataAccess
{
    public class UserDAO : IUserDAO
    {
        private readonly JWTDemoDbContext _jwtDemoDbContext;
        public UserDAO()
        {
           
        }
    }
}
