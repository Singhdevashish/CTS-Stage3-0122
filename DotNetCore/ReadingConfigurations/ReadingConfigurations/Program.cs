using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;
namespace ReadingConfigurations
{
    class Program
    {
        static void Main(string[] args)
        {
            var OutputDirPath = AppDomain.CurrentDomain.BaseDirectory;
            IConfiguration configuration = new ConfigurationBuilder()
                                                .SetBasePath(OutputDirPath)
                                                .AddJsonFile("appsettings.json")
                                                .Build();

            var Company = configuration["CompanyName"];
            Console.WriteLine($"Company name : {Company}");

            var DeveloperName = configuration["Developer:Name"];
            var DeveloperEmail = configuration["Developer:Email"];

            Console.WriteLine($"Developer name = {DeveloperName}, email = {DeveloperEmail}");

            var CognizantConn = configuration["ConnectionStrings:CognizantDb"];
            var DxcConn = configuration.GetConnectionString("DxcDB");

            Console.WriteLine(CognizantConn);
            Console.WriteLine(DxcConn);

            Console.ReadKey();
        }
    }
}
