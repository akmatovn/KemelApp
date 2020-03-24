using System;
using System.Linq;

namespace Kemel.DAL.Repository
{
    public interface IRepository
    {
        void Save(object obj);
        void Delete(object obj);
        object GetById(Type objType, object objId);
        IQueryable<TEntity> All<TEntity>();
    }
}
