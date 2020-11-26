using System;
using DangEasy.Configuration;

namespace Example.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");
            System.Console.WriteLine($"AppContext.BaseDirectory: {AppContext.BaseDirectory}");
            System.Console.WriteLine($"Directory.GetCurrentDirectory(): {System.IO.Directory.GetCurrentDirectory()}");
            System.Console.WriteLine();

            var configLoader = new ConfigurationLoader();

            // Directory.Root = /src/Example.Console
            var config = configLoader.Load("appsettings.json", Directory.Root);
            var value = config["AppSettings:Key"];
            System.Console.WriteLine("Directory.Root = /src/Example.Console");
            System.Console.WriteLine($"Absolute path: {configLoader.AbsoluteFilePath}");
            System.Console.WriteLine($"Value: {value}\n");


            // Directory.Bin = /src/Example.Console/bin/Debug/net5.0
            config = configLoader.Load("appsettings_bin.json", Directory.Bin);
            value = config["AppSettings:Key"];
            System.Console.WriteLine("Directory.Bin = /src/Example.Console/bin/Debug/net5.0");
            System.Console.WriteLine($"Absolute path: {configLoader.AbsoluteFilePath}");
            System.Console.WriteLine($"Value: {value}\n");


            // Directory.None = developer defined absolute path
            var custom = $"{AppContext.BaseDirectory}/appsettings_bin.json";
            config = configLoader.Load(custom, Directory.None);
            value = config["AppSettings:Key"];
            System.Console.WriteLine("Directory.None = developer defined absolute path");
            System.Console.WriteLine($"Absolute path: {configLoader.AbsoluteFilePath}");
            System.Console.WriteLine($"Value: {value}\n");


            // Directory.Current = Directory.GetCurrentDirectory()
            // When running from VS: /src/Example.Console/bin/Debug/net5.0
            // When running from command line, filename is relative to the working directory
            config = configLoader.Load("appsettings_bin.json", Directory.Current);
            value = config["AppSettings:Key"];
            System.Console.WriteLine("Directory.Current = directory where called from");
            System.Console.WriteLine($"Absolute path: {configLoader.AbsoluteFilePath}");
            System.Console.WriteLine($"Value: {value}\n");
        }
    }
}
