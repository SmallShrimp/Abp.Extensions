# Abp.Extension.Orm.Dapper
thanks [Abp.Dapper](https://github.com/aspnetboilerplate/aspnetboilerplate "Abp.Dapper"),[Dapper](https://github.com/StackExchange/Dapper "Dapper"),[DapperExtensions](https://github.com/tmsmith/Dapper-Extensions "DapperExtensions")

## how to use!
1. DependsOn
``` csharp
[DependsOn(typeof(OrmDapperModule))]
public class AbpZeroTemplateWebCoreModule : AbpModule
```
2. init database connectionString
open file Startup.cs
``` csharp
 public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory){
    	app.UseOrmDapper(connectionString);
    }
```
3. Use Repository



``` csharp

private readonly IDapperRepository<User, long> _useDapperRepository;
//1 use sql 
var output = (await _useDapperRepository.QueryAsync<User>("select * from AbpUsers")).ToList();
//2 no sql
var output = (await _useDapperRepository.GetListAsync<User>()).ToList();
//3 use uow
using (var uow = _useDapperRepository.Begin())
{
	var output = (await _useDapperRepository.QueryAsync<User>("select * from AbpUsers")).ToList();	
	uow.Dispose();
}

```


# Abp.Extension.Background

1. 引用dll
``` csharp
Install-Package Abp.Extension.Background


```
2. 添加任务类

``` csharp
public class TestTask : IHTask
    {

        public ILogger Logger { get; set; }
        public TestTask()
        {
            Logger = IocManager.Instance.Resolve<ILogger>();
        }

        public void Run()
        {
            Logger.Debug("测试任务执行.............");
        }

        public string Cron()
        {
            return Hangfire.Cron.Minutely();
        }
    }
```

3. 注册任务类

``` csharp 
//依赖
[DependsOn(typeof(AbpBackgroundModule))]
//注册
public override void PostInitialize()
        {
            
            var queue = IocManager.Resolve<BackTaskQueue>();
            queue.Add(typeof(TestTask).FullName, typeof(TestTask));

        }

```

4. Host项目startUp 启用hangfire

``` csharp
//a. ConfigureServices方法
services.AddHangfire(config =>
            {                
                config.UseMemoryStorage();
            });
//b.Configure方法
app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new AbpHangfireAuthorizationFilter(AppPermissions.Pages_Administration_HangfireDashboard) }
            });
app.UseHangfireServer();

app.RunHangfireTask();

```

Xugege19890911,.