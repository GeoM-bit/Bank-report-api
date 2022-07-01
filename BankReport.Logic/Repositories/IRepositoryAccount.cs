using System.Collections.Generic;

namespace BankReport.Logic.Repositories
{
    public interface IRepositoryAccount<TEntity,TId>
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(TId id);
        Task Post(TEntity entity);
        Task Put(TId id, TEntity entity);
        Task Delete(TId id);
        void Save();

    }
}
