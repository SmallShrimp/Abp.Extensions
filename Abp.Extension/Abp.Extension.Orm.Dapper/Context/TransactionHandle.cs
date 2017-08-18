using System;

namespace Abp.Extension.Orm.Dapper.Context
{
    /// <summary>
    /// default implementation of transaction handle
    /// </summary>
    class TransactionHandle : IDapperDbTransactionHandle
    {

        /// <summary>
        /// Triggered after Dispose is called
        /// </summary>
        public event EventHandler<EventArgs> Disposed;

        
        public TransactionHandle()
        {
        }

        public void Dispose()
        {

            OnDisposed();

        }

        protected virtual void OnDisposed()
        {
            var handler = Disposed;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}