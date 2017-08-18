using Abp.Domain.Entities;

namespace Abp.Extension.Orm.Dapper.Repositories
{
    public class DapperRepositoryBase<TEntity> : DapperRepositoryBase<TEntity, int>, IDapperRepository<TEntity>
        where TEntity : class, IEntity<int>
    {
        public DapperRepositoryBase()
        {
        }
    }
}
