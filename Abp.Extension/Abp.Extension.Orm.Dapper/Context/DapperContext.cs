using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Abp.Domain.Entities;
using Abp.Extension.Orm.Dapper.Repositories;
using MySql.Data.MySqlClient;

namespace Abp.Extension.Orm.Dapper.Context
{
    public abstract class DapperContext<TEntity, TPrimaryKey> : AbpDapperRepositoryBase<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected IDbConnection Connection;
        protected bool Disposed;
        protected IDbTransaction Transaction;

        protected IDbConnection GetConnection()
        {
            if (Connection == null) EnsureAnOpenConnection(CreareConnection());
            return Connection;
        }

        protected DapperContext()
        {
            EnsureAnOpenConnection(CreareConnection());
        }


        private static DbConnection CreareConnection()
        {
            switch (DatabaseConfig.DbType)
            {
                case DatabaseType.MsSql:
                    return new SqlConnection(DatabaseConfig.ConnectionString);
                case DatabaseType.MySql:
                    return new MySqlConnection(DatabaseConfig.ConnectionString);
                default: return new SqlConnection(DatabaseConfig.ConnectionString);
            }
        }

        public override IDapperUnitOfWork Begin(IsolationLevel isolationLevel)
        {
            if (Disposed)
            {
                throw new ObjectDisposedException(typeof(IDapperUnitOfWork).Name, "The unit of work is disposed. You cannot begin work with it.");
            }
            EnsureTransaction(isolationLevel);
            return this;
        }

        public override void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction = null;
            }
            Connection.Close();
        }

        public override void Rollback()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
                Transaction.Dispose();
                Transaction = null;
            }
        }

        public override void Dispose()
        {
            if (Disposed)
            {
                return;
            }

            if (Connection != null)
            {
                if (Transaction != null)
                {
                    Transaction.Commit();
                    Transaction = null;
                }

                Connection.Dispose(); //should close the connection
                Connection = null;
            }

            Disposed = true;
        }

        private void EnsureAnOpenConnection(IDbConnection connection = null)
        {
            if (connection != null)
            {
                this.Connection = connection;
            }

            if (this.Connection.State != ConnectionState.Open)
            {
                this.Connection.Open();
            }
        }

        protected virtual void EnsureTransaction(IsolationLevel isolationLevel)
        {
            EnsureAnOpenConnection();
            if (Transaction == null)
            {
                Transaction = Connection.BeginTransaction(isolationLevel); //underlying transaction
            }
            //var handle = new TransactionHandle();
            //handle.Disposed += (o, e) => Commit();

            //return handle;
        }
    }
}
