using DataAccess.Interface;
using Entity;
using System;
using System.Linq;
using System.Collections.Generic;

namespace DataAccess
{
    public class UserDAO : IBaseDAO<User>
    {
        private readonly JWTDemoDbContext _jwtDemoDbContext;
        public UserDAO(JWTDemoDbContext context)
        {
            _jwtDemoDbContext = context;
        }

        public void Add(User entity)
        {
            _jwtDemoDbContext.Users.Add(entity);
            _jwtDemoDbContext.SaveChanges();
        }

        public void Delete(User entity)
        {
            _jwtDemoDbContext.Users.Remove(entity);
            _jwtDemoDbContext.SaveChanges();
        }

        public User Get(long id)
        {
            return _jwtDemoDbContext.Users.SingleOrDefault(x => x.ID == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _jwtDemoDbContext.Users;
        }

        public void Update(User entity)
        {
            var dbEntity = _jwtDemoDbContext.Users.SingleOrDefault(x => x.ID == entity.ID);
            if (dbEntity != null)
            {
                dbEntity.Username = entity.Username;
                dbEntity.Password = entity.Password;
                _jwtDemoDbContext.SaveChanges();
            }         
        }      
    }
}
