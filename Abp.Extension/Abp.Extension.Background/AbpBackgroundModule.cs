using System;
using System.Reflection;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Abp.Extension.Background
{



    public class AbpBackgroundModule : AbpModule
    {
        public override void PreInitialize()
        {

        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpBackgroundModule).GetAssembly());
        }

        public override void PostInitialize()
        {

        }
    }
}
