// See https://aka.ms/new-console-template for more information
using ClashBard.Tow.ClassProducer.ConsoleApp.ArmyParsers;
using ClashBard.Tow.ClassProducer.ConsoleApp.Models;
using ClashBard.Tow.ClassProducer.ConsoleApp.WhfbAppScrapping;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using System.Text;

var logger = SetupLogging();

//var magicItemsJsonParser = new MagicItemsJsonParser();
//magicItemsJsonParser.ParseMagicItemsJson();


//ArmyHtmlScrapper armyHtmlScrapper = new(logger);

//await armyHtmlScrapper.ScrapeArmyHtml("dark-elves");


try
{
    string armyName = "dark-elves";

    logger.LogInformation("Starting class generation process");

    ArmyHtmlScrapperCharacters armyHtmlScrapperCharacters = new(logger);
    TowBuilderArmyParser armyParser = new(logger, armyHtmlScrapperCharacters);

    await armyParser.ParseArmy(armyName);

    logger.LogInformation("Character class generation completed");
}
catch (Exception ex)
{
    logger.LogError(ex, "Error during character class generation process");
}


static ILogger<Program> SetupLogging()
{
    var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)
        .CreateLogger();

    using var loggerFactory = LoggerFactory.Create(builder =>
    {
        builder
            .AddConfiguration(configuration.GetSection("Logging"))
            .AddSerilog(dispose: true);
    });

    ILogger<Program> logger = loggerFactory.CreateLogger<Program>();
    return logger;
}