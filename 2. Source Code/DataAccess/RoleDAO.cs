using DataAccess.Interface;
using Entity;
using System;
using System.Linq;
using System.Collections.Generic;

namespace DataAccess
{
    public class RoleDAO : IBaseDAO<Role>
    {
        private readonly JWTDemoDbContext _jwtDemoDbContext;
        public RoleDAO(JWTDemoDbContext context)
        {
            _jwtDemoDbContext = context;
        }

        public void Add(Role entity)
        {
            _jwtDemoDbContext.Roles.Add(entity);
            _jwtDemoDbContext.SaveChanges();
        }

        public void Delete(Role entity)
        {
            _jwtDemoDbContext.Roles.Remove(entity);
            _jwtDemoDbContext.SaveChanges();
        }

        public Role Get(long id)
        {
            return _jwtDemoDbContext.Roles.SingleOrDefault(x => x.ID == id);
        }

        public IEnumerable<Role> GetAll()
        {
            return _jwtDemoDbContext.Roles;
        }

        public void Update(Role entity)
        {
            var dbEntity = _jwtDemoDbContext.Roles.SingleOrDefault(x => x.ID == entity.ID);
            if (dbEntity != null)
            {
                dbEntity.Description = entity.Description;
                _jwtDemoDbContext.SaveChanges();
            }         
        }      
    }
}
