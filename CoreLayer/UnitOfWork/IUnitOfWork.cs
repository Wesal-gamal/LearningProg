using Attendleave.Erp.Core.Repository;
using System;
using System.Threading.Tasks;

namespace Attendleave.Erp.Core.UnitOfWork
{
    public interface IUnitOfWork<T> : IDisposable where T : class
    {
        IRepository<T> Repository { get; }
        Task<int> SaveChanges();
        void StartTransaction();
        void CommitTransaction();
        void Rollback();
    }
}
