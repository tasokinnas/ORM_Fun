namespace DapperSample
{
    using Microsoft.Extensions.Configuration;
    using System.IO;

    public class ConfigReader
    {
        static IConfigurationRoot config = null;

        static ConfigReader()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            config = builder.Build();
        }

        public static string ConnectionString
        {
            get
            {
                return config.GetSection("RepoSettings").GetValue<string>("connectionString");
            }
        }

        public static string ReadAllCommand
        {
            get
            {
                return config.GetSection("BookRepositorySettings").GetValue<string>("ReadAllCommand");
            }
        }

    }
}
