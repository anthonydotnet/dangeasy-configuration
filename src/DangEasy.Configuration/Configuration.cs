using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace DangEasy.Configuration
{
    public class ConfigurationLoader
    {
        public static Dictionary<Directory, string> BasePaths = new Dictionary<Directory, string>
            {
                {Directory.Bin, AppContext.BaseDirectory },
                {Directory.Current, System.IO.Directory.GetCurrentDirectory() },
                {Directory.Root, GetRoot() },
                {Directory.None, string.Empty }
            };

        public string AbsoluteFilePath { get; internal set; }

        public ConfigurationLoader()
        {
        }


        public IConfigurationRoot Load(string filename, Directory directory, bool optional = true, bool reloadOnChange = true)
        {
            AbsoluteFilePath = directory == Directory.None
                ? new FileInfo(filename).FullName
                : new FileInfo($"{BasePaths[directory]}/{filename}").FullName;

            return new ConfigurationBuilder()
                .AddJsonFile(AbsoluteFilePath, optional, reloadOnChange)
                .Build();
        }


        private static string GetRoot()
        {
            var directory = System.IO.Directory.GetParent(AppContext.BaseDirectory);

            while (directory.FullName.Contains("/bin/") || directory.FullName.EndsWith("/bin"))
            {
                if (directory.Parent == null) { break; }
                directory = directory.Parent;
            }

            return directory.FullName;
        }
    }
}
