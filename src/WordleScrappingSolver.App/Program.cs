// See https://aka.ms/new-console-template for more information
using System.Text.Json;

using WordleScrappingSolver.SeleniumExt;
using WordleScrappingSolver.SeleniumExt.WebLoaders;

Console.WriteLine("Hello, World!");

var configStr = File.ReadAllText("./configs.json");
var configurations = JsonSerializer.Deserialize<Dictionary<string, string>>(configStr);
var driver  = await ChromeDriverExt.GetChromeDriver(configurations!);
driver.Navigate().GoToUrl(configurations!["WordleLink"]);
var player = new WordlePlayer(driver, configurations);
player.StartPlay();