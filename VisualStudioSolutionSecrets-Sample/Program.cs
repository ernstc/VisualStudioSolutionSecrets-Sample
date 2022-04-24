using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using VisualStudioSolutionSecrets_Sample.Model;


var confBuilder = new ConfigurationBuilder();
confBuilder.AddJsonFile("appsettings.json");
confBuilder.AddUserSecrets("8f405b74-7c45-4f84-8fcf-2efa1d5208fa");
var configuration = confBuilder.Build();

Console.WriteLine("\nHello World!\n");
Console.WriteLine($"MySetting = {configuration["MySetting"]}\n");

string dbConnectionString = configuration.GetConnectionString("DemoContext");

var optionsBuilder = new DbContextOptionsBuilder<DemoContext>();
optionsBuilder.UseSqlServer(dbConnectionString);

DemoContext context = new DemoContext(optionsBuilder.Options);

Console.WriteLine("Products:\n");
Console.WriteLine($"{"Id" ,40} | {"Name", 20} | {"Quantity", 20}");
var products = context.Products.ToList();
foreach (var item in products)
{
    Console.WriteLine($"{item.Id, 40} | {item.Name, 20} | {item.Quantity, 20}");
}
Console.WriteLine("\n");