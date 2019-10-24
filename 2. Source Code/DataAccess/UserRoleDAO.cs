using DataAccess.Interface;
using Entity;
using System;
using System.Linq;
using System.Collections.Generic;

namespace DataAccess
{
    public class UserRoleDAO : IBaseDAO<UserRole>
    {
        private readonly JWTDemoDbContext _jwtDemoDbContext;
        public UserRoleDAO(JWTDemoDbContext context)
        {
            _jwtDemoDbContext = context;
        }

        public void Add(UserRole entity)
        {
            _jwtDemoDbContext.UserRoles.Add(entity);
            _jwtDemoDbContext.SaveChanges();
        }

        public void Delete(UserRole entity)
        {
            _jwtDemoDbContext.UserRoles.Remove(entity);
            _jwtDemoDbContext.SaveChanges();
        }

        public UserRole Get(long id)
        {
            return _jwtDemoDbContext.UserRoles.SingleOrDefault(x => x.ID == id);
        }

        public IEnumerable<UserRole> GetAll()
        {
            return _jwtDemoDbContext.UserRoles;
        }

        public void Update(UserRole entity)
        {
            var dbEntity = _jwtDemoDbContext.UserRoles.SingleOrDefault(x => x.ID == entity.ID);
            if (dbEntity != null)
            {
                dbEntity.RoleID = entity.RoleID;
                dbEntity.UserID = entity.UserID;
                _jwtDemoDbContext.SaveChanges();
            }         
        }      
    }
}
