# DangEasy.Configuration
A simple configuration loader for dotnet core and unit testing.

The problem this package is trying to solve is to unify the most common ways to load your appsettings.json into a simple library.


# Installation
Use NuGet to install the [package](https://www.nuget.org/packages/DangEasy.Configuration/).

```
PM> Install-Package DangEasy.Configuration
```


## Usage

```
var configLoader = new ConfigurationLoader();
var config = configLoader.Load("appsettings.json", Directory.Root);
var value = config["AppSettings:Key"];

```

### Options
* Directory.Current
	- When running console app from Visual Studio path is : /src/Example.Console/bin/Debug/net5.0
	- When running from command line, the path is relative to the working directory
* Directory.Bin
	- The location of your executable/DLLs eg. /src/Example.Console/bin/Debug/net5.0
	- Useful for unit testing. Note: Set appsettings.json to copy to bin on build
* Directory.Root
	- Useful for web applications, as appsettings.config is at the root of the deployed application
* Directory.None
	- Allows absolute path to be used for appsettings.config. 

When dealing with 


## Examples
```
var configLoader = new ConfigurationLoader();

// Directory.Root = /src/Example.Console
var config = configLoader.Load("appsettings.json", Directory.Root);
var value = config["AppSettings:Key"];
System.Console.WriteLine($"{value}");

// Directory.Bin = /src/Example.Console/bin/Debug/net5.0
config = configLoader.Load("appsettings_bin.json", Directory.Bin);
value = config["AppSettings:Key"];
System.Console.WriteLine($"{value}");

// Directory.None = developer defined absolute path
var custom = $"{AppContext.BaseDirectory}/appsettings.json";
config = configLoader.Load(custom, Directory.None);
value = config["AppSettings:Key"];
System.Console.WriteLine($"{value}");

// Directory.Current = Directory.GetCurrentDirectory()
// When running from VS: /src/Example.Console/bin/Debug/net5.0
// When running from command line, filename is relative to the working directory
config = configLoader.Load("appsettings.json", Directory.Current);
value = config["AppSettings:Key"];
System.Console.WriteLine($"{value}");


```


# License

DangEasy.Configuration is provided under the MIT license.


