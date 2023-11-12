using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class AppSettings
    {
        private static AppSettings? instance;
        private readonly IConfigurationRoot configuration;
        private AppSettings() {
            configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        private static AppSettings GetInstance() {
            instance ??= new AppSettings();
            return instance;
        }

        public static string? ConnectionString()
        {
            return GetInstance()
                ?.configuration
                ?.GetConnectionString("WebAuthDBConnection");
        }
    }
}
