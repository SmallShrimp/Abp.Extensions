namespace Abp.Extension.Orm.Dapper
{
    public class DatabaseConfig
    {

        public static string ConnectionString = "Default";
        public static DatabaseType DbType = DatabaseType.MsSql;

    }

    public enum DatabaseType
    {
        MsSql = 0,
        MySql
    }
}
