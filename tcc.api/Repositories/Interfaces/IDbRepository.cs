using System;

namespace tcc.api.Repositories.Interfaces
{
    public interface IDbRepository<T>
    {
        Task<IEnumerable<T>> GetItems();
        T Insert(T item);
        string ResetDB();
    }
}
