# Abp.Extension.Orm.Dapper
thanks [Abp.Dapper](https://github.com/aspnetboilerplate/aspnetboilerplate "Abp.Dapper"),[Dapper](https://github.com/StackExchange/Dapper "Dapper"),[DapperExtensions](https://github.com/tmsmith/Dapper-Extensions "DapperExtensions")

## how to use!
1. DependsOn
```csharp
[DependsOn(typeof(OrmDapperModule))]
public class AbpZeroTemplateWebCoreModule : AbpModule
```
2. init database connectionString
open file Startup.cs
```csharp
 public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory){
    	app.UseOrmDapper(connectionString);
    }
```
3. Use Repository



```csharp

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
