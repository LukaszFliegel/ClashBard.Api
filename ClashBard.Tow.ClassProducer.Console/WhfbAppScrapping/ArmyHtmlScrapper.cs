using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.ClassProducer.ConsoleApp.WhfbAppScrapping;
public class ArmyHtmlScrapper
{
    ILogger logger;

    ArmyHtmlScrapperCharacters armyHtmlScrapperCharacters;

    const string baseUrl = "https://tow.whfb.app/";

    public ArmyHtmlScrapper(ILogger logger)
    {
        this.logger = logger;

        armyHtmlScrapperCharacters = new(logger);
    }

    public async Task ScrapeArmyHtml(string armyName)
    {
        var armyPath = new Uri(new Uri(baseUrl), "/army/");
        var url = new Uri(armyPath, armyName);
        var doc = new HtmlDocument();
        string html = string.Empty;

        // Create HTTP client
        using (var client = new HttpClient())
        {
            // Download the page content
            
            html = await client.GetStringAsync(url);
            
            doc.LoadHtml(html);
        }

        logger.LogInformation("Scraping {armyName} html with url {url}", armyName, url);


        // Find the section with Character Units
        var nodes = doc.DocumentNode
            .SelectNodes("//div[contains(@class, 'unit-section')]");

        var characterUnitsSection = nodes
            .FirstOrDefault(div => div.SelectSingleNode(".//h3/a")?.InnerText.Contains("Character Units") ?? false);

        if (characterUnitsSection != null)
        {
            var characterLinks = characterUnitsSection.SelectNodes(".//ul/li/span/a");

            if (characterLinks != null)
            {
                foreach (var link in characterLinks)
                {
                    string characterName = link.InnerText.Trim();
                    string characterUrl = link.GetAttributeValue("href", string.Empty);
                    //armyHtmlScrapperCharacters.ScrapeCharacterHtml(characterUrl);
                }
            }
        }
    }
}
