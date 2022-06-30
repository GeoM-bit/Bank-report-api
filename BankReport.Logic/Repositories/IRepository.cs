using System.Collections.Generic;

namespace BankReport.Logic.Repositories
{
    public interface IRepository<T,K>
    {
        IQueryable<T> GetAll();
        T GetById(K id);
        void Post(T entity);
        void Put(K id);
        void Delete(K id);

    }
}
