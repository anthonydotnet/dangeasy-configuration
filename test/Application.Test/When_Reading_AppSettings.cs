using System;
using DangEasy.Configuration;
using Xunit;

namespace Application.Test
{
    public class When_Reading_AppSettings
    {
        [Fact]
        public void AbsolutePath_Has_Value()
        {
            // Note: appsettings.json is NOT copied to bin
            var fullPath = $"{AppContext.BaseDirectory}../../../appsettings.json";

            var config = new ConfigurationLoader().Load(fullPath, Directory.None);

            Assert.Equal("Value", config["AppSettings:Key"]);
        }


        [Fact]
        public void Root_Has_Value()
        {
            // Note: appsettings.json is NOT copied to bin
            var config = new ConfigurationLoader().Load("appsettings.json", Directory.Root);

            Assert.Equal("Value", config["AppSettings:Key"]);
        }
    }
}
