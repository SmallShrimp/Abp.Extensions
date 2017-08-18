using System;
using System.Data;

namespace Abp.Extension.Orm.Dapper.Context
{
    /// <summary>
    /// Unit of work that can be extended.
    /// </summary>
    public interface IDapperUnitOfWork : IDisposable
    {

        IDapperUnitOfWork Begin(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        /// <summary>
        /// Commits the changes
        /// </summary>
        void Commit();

        /// <summary>
        /// Rolls back the changes since Begin was called
        /// </summary>
        void Rollback();
    }
}