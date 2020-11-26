using System;
using DangEasy.Configuration;
using Xunit;

namespace Application.Test
{
    public class When_Reading_AppSettings_From_Bin
    {
        [Fact]
        public void Current_Setting_Has_Value()
        {
            var config = new ConfigurationLoader().Load("appsettings_bin.json", Directory.Current);

            Assert.Equal("Value", config["AppSettings:Key"]);
        }

        [Fact]
        public void Bin_Has_Value()
        {
            var config = new ConfigurationLoader().Load("appsettings_bin.json", Directory.Bin);

            Assert.Equal("Value", config["AppSettings:Key"]);
        }
    }
}
