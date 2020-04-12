using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
namespace Employee.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>()
            .UseSerilog
            (
                (context,logConfig)=>
                {
                    if(!context.HostingEnvironment.IsDevelopment())
                    {
                        logConfig.ReadFrom.Configuration(context.Configuration)
                        .WriteTo.Console(outputTemplate: "{timespam:yyyy-MM-dd HH:mm:ss} [{RequestId} | {Level} | {SourceContext:l}] - {Message}{NewLine}{Exception}");
                    }
                    else
                    {
                        logConfig.ReadFrom.Configuration(context.Configuration)
                        .Enrich.FromLogContext();
                    }
                }
            );
    }
}
