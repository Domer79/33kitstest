using System;
using System.Collections.Generic;

namespace CommonContracts
{
    public interface IRepository<TEntity> where TEntity: Entity
    {
        TEntity Get(Guid id);
        IEnumerable<TEntity> Get();
        IEntityCollectionInfo<TEntity> GetEntityCollectionInfo(int pageNumber, int pageSize);
        Guid Create(TEntity entity);
        void Update(TEntity entity);
        void Remove(Guid id);
    }
}