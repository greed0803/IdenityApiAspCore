//using Microsoft.Extensions.Configuration;
//var builder = new ConfigurationBuilder();
//builder.SetBasePath(Directory.GetCurrentDirectory())
//       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

//IConfiguration config = builder.Build();
//string connectionString = config["ConnectionString:SqlServer"];
//builder.SetBasePath(Directory.GetCurrentDirectory())
//       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//       .AddEnvironmentVariables();

//Console.WriteLine("Hello, World!");
using Data.Context;

foreach (var item in IdentityProviderContext.GetContext().Statuses)
{
    Console.WriteLine(item.Id);
    
}

foreach (var item in IdentityProviderContext.GetContext().UserTypes)
{
    Console.WriteLine(item.Id);

}

foreach (var item in IdentityProviderContext.GetContext().Users)
{
    Console.WriteLine(item.Id);

}