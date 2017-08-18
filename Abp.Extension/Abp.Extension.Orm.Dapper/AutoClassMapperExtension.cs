using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using DapperExtensions.Mapper;

namespace Abp.Extension.Orm.Dapper
{
    public sealed class AutoClassMapperExtension<T> : ClassMapper<T> where T : class
    {
        public AutoClassMapperExtension()
        {
            Type type = typeof(T);
            TableAttribute ta = type.GetCustomAttribute<TableAttribute>(true);
            Table(ta?.Name ?? type.Name);
            AutoMap();
        }
    }
}
