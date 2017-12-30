using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;

namespace Abp.Extension.Background.H
{
    public class BackTaskQueue : ISingletonDependency
    {

        public BackTaskQueue()
        {
            Items = new Dictionary<string, Type>();
        }
        private IDictionary<string, Type> Items;

        public void Add(string key, Type task)
        {
            if (!Items.ContainsKey(key))
            {
                Items.Add(key, task);
            }
        }

        public Type Get(string key)
        {
            if (Items.ContainsKey(key)) return Items[key];
            return null;
        }

        public IDictionary<string, Type> Queue()
        {
            return Items;
        }
    }
}
