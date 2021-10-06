using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNPblazorAssignment.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DNPblazorAssignment
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // IAdultManager adultManager = new AdultManager();
            // Console.WriteLine(adultManager.GetAdult(0).JobTitle.JobTitle);
            // adultManager.RemoveAdult(14);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}