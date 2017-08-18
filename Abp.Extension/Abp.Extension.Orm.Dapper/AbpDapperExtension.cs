
using Owin;

namespace Abp.Extension.Orm.Dapper
{
    public static class AbpDapperExtension
    {
        /// <summary>
        /// 配置dapper数据库连接上下文
        /// </summary>
        /// <param name="app"></param>
        /// <param name="connectionString">连接字符串</param>
        /// <returns></returns>
        public static IAppBuilder UseOrmDapper(this IAppBuilder app, string connectionString)
        {
            //配置dapper
            DatabaseConfig.ConnectionString = connectionString;
            return app;
        }
        /// <summary>
        /// 配置dapper数据库连接上下文
        /// </summary>
        /// <param name="app"></param>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="dbType">数据库类型</param>
        /// <returns></returns>
        public static IAppBuilder UseOrmDapper(this IAppBuilder app, string connectionString, DatabaseType dbType)
        {
            //配置dapper
            DatabaseConfig.ConnectionString = connectionString;
            DatabaseConfig.DbType = dbType;
            return app;
        }
    }
}
