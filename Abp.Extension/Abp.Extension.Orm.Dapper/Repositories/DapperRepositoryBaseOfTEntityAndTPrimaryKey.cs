using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Extension.Orm.Dapper.Context;
using Abp.Extension.Orm.Dapper.Expressions;
using Abp.Extension.Orm.Dapper.Extensions;
using Dapper;
using DapperExtensions;

namespace Abp.Extension.Orm.Dapper.Repositories
{
    public class DapperRepositoryBase<TEntity, TPrimaryKey> : DapperContext<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>

    {



        public DapperRepositoryBase()
        {

        }

        public override TEntity Get(TPrimaryKey id)
        {
            return GetConnection().Get<TEntity>(id, transaction: Transaction);
        }

        public override Task<TEntity> GetAsync(TPrimaryKey id)
        {

            return GetConnection().GetAsync<TEntity>(id, transaction: Transaction);
        }

        public override IEnumerable<TEntity> GetList()
        {
            return GetConnection().GetList<TEntity>(transaction: Transaction);
        }

        public override IEnumerable<TEntity> GetList(object predicate)
        {
            return GetConnection().GetList<TEntity>(predicate, transaction: Transaction);
        }

        public override Task<IEnumerable<TEntity>> GetListAsync()
        {
            return GetConnection().GetListAsync<TEntity>(transaction: Transaction);
        }

        public override Task<IEnumerable<TEntity>> GetListAsync(object predicate)
        {
            return GetConnection().GetListAsync<TEntity>(predicate, transaction: Transaction);
        }

        public override IEnumerable<TEntity> GetListPaged(
            object predicate,
            int pageNumber,
            int itemsPerPage,
            string sortingProperty,
            bool ascending = true)
        {
            return GetConnection().GetPage<TEntity>(
                predicate,
                new List<ISort> { new Sort { Ascending = ascending, PropertyName = sortingProperty } },
                pageNumber,
                itemsPerPage
                , transaction: Transaction
                );
        }

        public override Task<IEnumerable<TEntity>> GetListPagedAsync(
            object predicate,
            int pageNumber,
            int itemsPerPage,
            string sortingProperty,
            bool ascending = true)
        {
            return GetConnection().GetPageAsync<TEntity>(
                predicate,
                new List<ISort> { new Sort { Ascending = ascending, PropertyName = sortingProperty } },
                pageNumber,
                itemsPerPage, transaction: Transaction
                );
        }

        public override int Count(object predicate)
        {
            return GetConnection().Count<TEntity>(predicate, transaction: Transaction);
        }

        public override Task<int> CountAsync(object predicate)
        {
            return GetConnection().CountAsync<TEntity>(predicate, transaction: Transaction);
        }

        public override IEnumerable<TEntity> Query(string query, object parameters)
        {
            return GetConnection().Query<TEntity>(query, parameters, transaction: Transaction);
        }

        public override Task<IEnumerable<TEntity>> QueryAsync(string query, object parameters)
        {
            return GetConnection().QueryAsync<TEntity>(query, parameters, transaction: Transaction);
        }

        public override IEnumerable<TAny> Query<TAny>(string query)
        {
            return GetConnection().Query<TAny>(query, transaction: Transaction);
        }

        public override Task<IEnumerable<TAny>> QueryAsync<TAny>(string query)
        {
            return GetConnection().QueryAsync<TAny>(query, transaction: Transaction);
        }

        public override IEnumerable<TAny> Query<TAny>(string query, object parameters)
        {
            return GetConnection().Query<TAny>(query, parameters, transaction: Transaction);
        }

        public override Task<IEnumerable<TAny>> QueryAsync<TAny>(string query, object parameters)
        {
            return GetConnection().QueryAsync<TAny>(query, parameters, transaction: Transaction);
        }

        public override IEnumerable<TEntity> GetSet(object predicate, int firstResult, int maxResults, string sortingProperty, bool ascending = true)
        {
            return GetConnection().GetSet<TEntity>(
                predicate,
                new List<ISort> { new Sort { Ascending = ascending, PropertyName = sortingProperty } },
                firstResult,
                maxResults, transaction: Transaction
                );
        }

        public override Task<IEnumerable<TEntity>> GetSetAsync(object predicate, int firstResult, int maxResults, string sortingProperty, bool ascending = true)
        {
            return GetConnection().GetSetAsync<TEntity>(
                predicate,
                new List<ISort> { new Sort { Ascending = ascending, PropertyName = sortingProperty } },
                firstResult,
                maxResults, transaction: Transaction
                );
        }

        public override IEnumerable<TEntity> GetListPaged(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, string sortingProperty, bool ascending = true)
        {
            return GetConnection().GetPage<TEntity>(
                predicate.ToPredicateGroup<TEntity, TPrimaryKey>(),
                new List<ISort> { new Sort { Ascending = ascending, PropertyName = sortingProperty } },
                pageNumber,
                itemsPerPage, transaction: Transaction
                );
        }

        public override int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return GetConnection().Count<TEntity>(predicate.ToPredicateGroup<TEntity, TPrimaryKey>());
        }

        public override IEnumerable<TEntity> GetSet(Expression<Func<TEntity, bool>> predicate, int firstResult, int maxResults, string sortingProperty, bool ascending = true)
        {
            return GetConnection().GetSet<TEntity>(
                predicate.ToPredicateGroup<TEntity, TPrimaryKey>(),
                new List<ISort> { new Sort { Ascending = ascending, PropertyName = sortingProperty } },
                firstResult,
                maxResults, transaction: Transaction

            );
        }

        public override IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            return GetConnection().GetList<TEntity>(predicate?.ToPredicateGroup<TEntity, TPrimaryKey>(), transaction: Transaction);
        }

        public override Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return GetConnection().GetListAsync<TEntity>(predicate.ToPredicateGroup<TEntity, TPrimaryKey>(), transaction: Transaction);
        }

        public override Task<IEnumerable<TEntity>> GetSetAsync(Expression<Func<TEntity, bool>> predicate, int firstResult, int maxResults, string sortingProperty, bool ascending = true)
        {
            return GetConnection().GetSetAsync<TEntity>(
                predicate.ToPredicateGroup<TEntity, TPrimaryKey>(),
                new List<ISort> { new Sort { Ascending = ascending, PropertyName = sortingProperty } },
                firstResult,
                maxResults
                , transaction: Transaction
            );
        }

        public override Task<IEnumerable<TEntity>> GetListPagedAsync(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, string sortingProperty, bool ascending = true)
        {
            return GetConnection().GetPageAsync<TEntity>(
                predicate.ToPredicateGroup<TEntity, TPrimaryKey>(),
                new List<ISort> { new Sort { Ascending = ascending, PropertyName = sortingProperty } },
                pageNumber,
                itemsPerPage, transaction: Transaction
                );
        }

        public override Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return GetConnection().CountAsync<TEntity>(predicate.ToPredicateGroup<TEntity, TPrimaryKey>(), transaction: Transaction);
        }

        public override IEnumerable<TEntity> GetListPaged(Expression<Func<TEntity, bool>> predicate, int pageNumber, int itemsPerPage, bool ascending = true, params Expression<Func<TEntity, object>>[] sortingExpression)
        {
            return GetConnection().GetPage<TEntity>(predicate.ToPredicateGroup<TEntity, TPrimaryKey>(), sortingExpression.ToSortable(ascending), pageNumber, itemsPerPage, transaction: Transaction);
        }

        public override IEnumerable<TEntity> GetSet(Expression<Func<TEntity, bool>> predicate, int firstResult, int maxResults, bool ascending = true, params Expression<Func<TEntity, object>>[] sortingExpression)
        {
            return GetConnection().GetSet<TEntity>(predicate.ToPredicateGroup<TEntity, TPrimaryKey>(), sortingExpression.ToSortable(ascending), firstResult, maxResults, transaction: Transaction);
        }

        public override void Insert(TEntity entity)
        {
            GetConnection().Insert(entity, transaction: Transaction);
        }

        public override void Update(TEntity entity)
        {
            GetConnection().Update(entity, transaction: Transaction);
        }

        public override void Delete(TEntity entity)
        {
            GetConnection().Delete(entity, transaction: Transaction);
        }

        public override void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            GetConnection().Delete(predicate.ToPredicateGroup<TEntity, TPrimaryKey>(), transaction: Transaction);
        }

        public override TPrimaryKey InsertAndGetId(TEntity entity)
        {
            return GetConnection().Insert(entity, transaction: Transaction);
        }
    }
}
