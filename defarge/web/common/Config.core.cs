
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Data.Common;

namespace defarge
{
    public class Config
    {
        static IConfiguration configBuilder = null;

        static IConfiguration getConfigBuilder()
        {
            if (configBuilder == null)
            {
                configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            }

            return configBuilder;
        }
        static public string getString(string param)
        {
            string result = string.Empty;

            if (param == "db.connection")
            {
                result = getDbConnection();
            }
            else
            {
                IConfigurationSection section = getConfigBuilder().GetSection("appsettings");
                result = section[param];
            }

            return result;
        }

        static public string getDbConnection()
        {
            // Path to the .namespace file in the user's home directory
            string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string filePath = Path.Combine(homeDirectory, ".defarge");

            // Check if the file exists
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The .defarge file was not found in the user's home directory.", filePath);
            }

            // Read the file content
            string fileContent = File.ReadAllText(filePath).Trim();

            // Split the content by colon (:) to extract parameters
            string[] parameters = fileContent.Split(':');
            if (parameters.Length != 5)
            {
                throw new FormatException("The .defarge file must contain exactly five parameters separated by colons (:).\nserver:port:database:user:password");
            }

            string server = parameters[0];
            string port = parameters[1];
            string database = parameters[2];
            string username = parameters[3];
            string password = parameters[4];

            // Create the connection string
            string dbcon = "Host=^server;Port=^port;Username=^username;Password=^password;Database=^database;";
            dbcon = dbcon.Replace("^server", server)
                        .Replace("^port", port)
                        .Replace("^database", database)
                        .Replace("^username", username)
                        .Replace("^password", password);

            return dbcon;
        }
        
        static public int getInt(string param)
        {
            IConfigurationSection section = getConfigBuilder().GetSection("appsettings");

            return Convert.ToInt32(section[param]);
        }
    }
}
