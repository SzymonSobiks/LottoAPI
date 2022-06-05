using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace LottoAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Sleep 10s to allow the database to be created
            System.Threading.Thread.Sleep(10000);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
