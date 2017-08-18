using System;

namespace Abp.Extension.Orm.Dapper.Context
{
    
    public interface IDapperDbTransactionHandle : IDisposable
    {
        /// <summary>
        /// Triggered after Dispose is called
        /// </summary>
        event EventHandler<EventArgs> Disposed;

        /// <summary>
        ///// Gets the isolation level
        ///// </summary>
        //IsolationLevel IsolationLevel { get; }
    }
}