using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using To_Do_Lists.Data;
using To_Do_Lists.Data.Entities;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;


namespace To_Do_Lists
{
    class Program
    {

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
    }
}