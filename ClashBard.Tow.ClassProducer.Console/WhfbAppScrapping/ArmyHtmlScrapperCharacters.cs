using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.ClassProducer.ConsoleApp.WhfbAppScrapping;
public class ArmyHtmlScrapperCharacters
{
    private readonly ILogger logger;

    const string baseUrl = "https://tow.whfb.app/";
    private static readonly HttpClient _httpClient = new HttpClient();

    public ArmyHtmlScrapperCharacters(ILogger logger)
    {
        this.logger = logger;
    }

    public async Task<ScrappedCharacter> ScrapeCharacterStatsHtml(string characterName)
    {
        var unitBaseUrl = new Uri(new Uri(baseUrl), "/unit/");
        var url = new Uri(unitBaseUrl, characterName);
        var doc = new HtmlDocument();
        string html = string.Empty;

        logger.LogInformation("Scraping {characterName} html with url {url}", characterName, url);


        html = await _httpClient.GetStringAsync(url);

        ScrappedCharacter scrappedCharacter = new();

        doc.LoadHtml(html);

        var cells = doc.DocumentNode.SelectNodes("//table[contains(@class, 'unit-profile-table')]//tr[contains(@class, 'css-1sydf7g')]/td");
        if (cells == null)
        {
            throw new Exception("Failed to scrape character stats");
        }

        ///html/body/div[1]/div/div/main/div/div[2]/div[2]/div[3]/span[1]/span/a

        scrappedCharacter.Stats = new List<string>
        {
            cells[1].InnerText,
            cells[2].InnerText,
            cells[3].InnerText,
            cells[4].InnerText,
            cells[5].InnerText,
            cells[6].InnerText,
            cells[7].InnerText,
            cells[8].InnerText,
            cells[9].InnerText
        };

        var unitCategory = doc.DocumentNode.SelectNodes("//div[contains(@class, 'unit-profile__details--troop-type')]//span//span//a");
        if (unitCategory == null)
        {
            throw new Exception("Failed to scrape character stats");
        }

        scrappedCharacter.UnitCategory = unitCategory[0].InnerText;

        var baseSize = doc.DocumentNode.SelectNodes("//div[contains(@class, 'unit-profile__details--base-size')]");

        if (baseSize == null)
        {
            throw new Exception("Failed to scrape character stats");
        }

        scrappedCharacter.BaseSize = GetBaseSizeFromHtml(baseSize[0].InnerHtml);

        return scrappedCharacter;
    }

    private static (int?, int?) GetBaseSizeFromHtml(string baseSize)
    {
        if (baseSize.Contains("25 x 25 mm"))
        {
            return (25, 25);
        }

        if (baseSize.Contains("(as mount)"))
        {
            return (null, null);
        }

        throw new Exception("Failed to scrape base size");
    }
}

public class ScrappedCharacter
{
    public List<string> Stats { get; set; }

    public string UnitCategory { get; set; }

    public (int?, int?) BaseSize { get; set; }
}
