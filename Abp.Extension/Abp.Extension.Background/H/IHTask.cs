using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;

namespace Abp.Extension.Background.H
{
    public interface IHTask : ITransientDependency
    {
        void Run();
        string Cron();
    }
}
