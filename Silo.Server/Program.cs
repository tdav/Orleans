using Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

static async Task<IHost> StartSileAsync()
{
    var conf = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, false).Build();
    var builder = Host
         .CreateDefaultBuilder()
         .ConfigureServices(s =>
         {
             s.AddMyDatabaseService(conf);
         })
         .UseOrleans((context, silo) =>
         {
             silo.UseLocalhostClustering();
         }).ConfigureLogging(logging => logging.AddConsole());

    var host = builder.Build();

    await host.StartAsync();

    return host;
}

try
{
    using IHost host = await StartSileAsync();
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("--------------------------------------------------------");
    Console.WriteLine("                  Press Enter to exit");
    Console.WriteLine("--------------------------------------------------------");
    Console.WriteLine("");
    Console.ReadLine();

    await host.StopAsync();

    return 0;
}
catch (Exception ee)
{
    Console.WriteLine(ee.Message);
    return 1;
}
