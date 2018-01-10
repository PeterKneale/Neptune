using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Neptune.Services.Common.Data
{
    public interface IDataSource<T, TKey> where T : class, IDataRecord<TKey>
    {
        void Save(T item);
        Task SaveAsync(T item);
        IEnumerable<T> List();
        T Get(TKey id);
        Task<T> GetAsync(TKey id);
        bool Exists(TKey id);
        void Delete(TKey id);
        Task DeleteAsync(TKey id);
        void Update(T item);
        Task UpdateAsync(T item);
    }

    public abstract class BaseDataSource<T, TKey> : IDataSource<T, TKey> where T : class, IDataRecord<TKey>
    {
        protected IDbTransaction Transaction;
        protected IDbConnection Connection;

        public BaseDataSource(IDbConnection connection, IDbTransaction transaction)
        {
            Connection = connection;
            Transaction = transaction;
        }

        public void Save(T item)
        {
            Connection.Insert<TKey, T>(item, Transaction);
        }

        public async Task SaveAsync(T item)
        {
            await Connection.InsertAsync<TKey, T>(item, Transaction);
        }

        public void Update(T item)
        {
            Connection.Update(item, Transaction);
        }

        public Task UpdateAsync(T item)
        {
            return Connection.UpdateAsync(item, Transaction);
        }

        public void Delete(TKey id)
        {
            Connection.Delete<T>(id, Transaction);
        }

        public async Task DeleteAsync(TKey id)
        {
            await Connection.DeleteAsync<T>(id, Transaction);
        }

        public T Get(TKey id)
        {
            return Connection.Get<T>(id, Transaction);
        }

        public Task<T> GetAsync(TKey id)
        {
            return Connection.GetAsync<T>(id, Transaction);
        }

        public IEnumerable<T> List()
        {
            return Connection.GetList<T>(null, transaction: Transaction);
        }

        public bool Exists(TKey id)
        {
            return Get(id) != null;
        }
    }
}
