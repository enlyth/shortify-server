using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Shortify.Models;

namespace Shortify
{
    public class Program
    {
        static void TestStuff()
        {
            var tree = new WordTrie<string>("root");
            tree.AddChild("asd");
            tree.AddChild("dasd");
            var a = tree.Flatten();
            foreach (var x in a)
            {
                Console.WriteLine(x);
            }

        }

        public static void Main(string[] args)
        {
            TestStuff();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging(config =>
                {
                    config.ClearProviders();
                })
                .UseStartup<Startup>();
    }
}
