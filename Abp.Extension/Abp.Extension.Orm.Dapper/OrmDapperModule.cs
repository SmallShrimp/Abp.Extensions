using System.Reflection;
using Abp.Modules;

namespace Abp.Extension.Orm.Dapper
{


    public class OrmDapperModule : AbpModule
    {
        public override void PreInitialize()
        {
            base.PreInitialize();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            DapperExtensions.DapperExtensions.DefaultMapper = typeof(AutoClassMapperExtension<>);
        }
    }
}
