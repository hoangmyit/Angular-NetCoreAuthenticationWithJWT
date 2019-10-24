using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interface
{
    public interface IBaseDAO<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
