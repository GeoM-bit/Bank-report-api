using System.Collections.Generic;

namespace BankReport.Logic.Repositories
{
    public interface IRepository<T,Dto, K>
    {
        IQueryable<Dto> GetAll();
        Dto GetById(K id);
        void Post(T entity);
        void Put(K id);
        void Delete(K id);
        void Save();

    }
}
