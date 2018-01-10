using System;
using System.Data;

namespace Neptune.Services.Common.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }

    public abstract class BaseUnitOfWork : IUnitOfWork
    {
        protected IDbTransaction Transaction { get; private set; }
        protected IDbConnection Connection { get; private set; }
        private bool _disposed;

        public BaseUnitOfWork(IConnectionFactory factory)
        {
            Connection = factory.Open();
            Transaction = Connection.BeginTransaction();
        }

        public void Commit()
        {
            try
            {

                Transaction.Commit();
            }
            catch
            {
                Transaction.Rollback();
                throw;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (Transaction != null)
                    {
                        Transaction.Dispose();
                        Transaction = null;
                    }
                    if (Connection != null)
                    {
                        Connection.Dispose();
                        Connection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~BaseUnitOfWork()
        {
            Dispose(false);
        }
    }
}
