using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace CAMSlive.Api
{
    public class Program
    {
        //using Serilog
        //public static void Main(string[] args)
        public static int Main(string[] args)
        {
            //Serilog
            Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            //.WriteTo.File(@"C:\logs\log.txt
            //.WriteTo.Console()
            .WriteTo.Debug()
            .WriteTo.File(@"C:\Users\Trevor\Desktop\fresh\CAMSlive\CAMSlive\CAMSlive\CAMSlive\SerilogApi.txt")
            .CreateLogger();

            try
            {
                Log.Information("Starting CAMSlive.Api");
                CreateHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "CAMSlive.Api terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }

            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
               .UseSerilog();//Serilog
    }
}
