using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Extension.Background.H;
using Hangfire;

namespace Abp.Extension.Background
{
    public static class AppExtension
    {

        public static IApplicationBuilder RunHangfireTask(this IApplicationBuilder app)
        {
            var task = IocManager.Instance.Resolve<BackTaskQueue>();
            foreach (var type in task.Queue())
            {

                //var t = (Syncer)Activator.CreateInstance(type.Value);
                var t = IocManager.Instance.Resolve<IHTask>(type.Value);
                RecurringJob.AddOrUpdate(() => t.Run(), t.Cron);
            }
            return app;
        }

    }
}
