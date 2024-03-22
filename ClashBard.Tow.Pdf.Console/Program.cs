using ClashBard.Tow.DataAccess;
using ClashBard.Tow.Pdf.Console;
using ClashBard.Tow.StaticData.FactionRepositories;
using ClashBard.Tow.StaticData.Repositories;
using ClashBard.Tow.StaticData.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

IConfiguration configuration = builder.Build();

var services = new ServiceCollection();
services.AddDbContext<TowDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("ClashBardConnection")));
services.AddTransient<SampleArmyList>();
services.AddTransient<DarkElvesRepository>();
services.AddTransient<IFactionsListRepository, FactionsListRepository>();
services.AddTransient<IWeaponsRepository, WeaponsRepository>();
services.AddTransient<IArmorsRepository, ArmorsRepository>();
services.AddTransient<ISpecialRulesRepository, SpecialRulesRepository>();


var serviceProvider = services.BuildServiceProvider();

var sampleArmyList = serviceProvider.GetService<SampleArmyList>();

var army = sampleArmyList.GetSampleDarkElfArmy();

Document.Create(container =>
{

    float fontSize = 10;
    container.Page(page =>
    {
        page.Size(PageSizes.A4);
        page.Margin(12, Unit.Point);

        page.Header().Border(1).Table(table =>
        {
            table.ColumnsDefinition(columns =>
            {
                columns.RelativeColumn();
                columns.RelativeColumn();
            });


            table.Cell().Row(1).Column(1).Padding(4).AlignRight().Text($"{army.Points} Pts");
            table.Cell().Row(1).Column(2).Padding(4).AlignLeft().Text($"{army.Faction.FactionType} Roster");
        });

        //page.Content().PaddingVertical(1, Unit.Centimetre)
        //    .Column(x => {
        //        x.Spacing(10);
        //        x.Item().Text("Name: Malekith");
        //        x.Item().Text("Points: 500");
        //    });

        page.Content().Border(1).Table(table =>
        {
            table.ColumnsDefinition(columns =>
            {
                columns.RelativeColumn(8);
                columns.RelativeColumn(1);
                columns.RelativeColumn(1);
                columns.RelativeColumn(1);
                columns.RelativeColumn(1);
                columns.RelativeColumn(1);
                columns.RelativeColumn(1);
                columns.RelativeColumn(1);
                columns.RelativeColumn(1);
                columns.RelativeColumn(1);
                columns.RelativeColumn(1);
                columns.RelativeColumn(1);
                columns.RelativeColumn(1);
                columns.RelativeColumn(1);
                columns.RelativeColumn(1);
                columns.RelativeColumn(1);
                columns.RelativeColumn(2);
            });

            table.Cell().Row(1).Column(1).Element(Block).Text("Unit Name").FontSize(fontSize);
            table.Cell().Row(1).Column(2).Element(Block).Text("#").FontSize(fontSize);
            table.Cell().Row(1).Column(3).Element(Block).Text("M").FontSize(fontSize);
            table.Cell().Row(1).Column(4).Element(Block).Text("WS").FontSize(fontSize);
            table.Cell().Row(1).Column(5).Element(Block).Text("BS").FontSize(fontSize);
            table.Cell().Row(1).Column(6).Element(Block).Text("S").FontSize(fontSize);
            table.Cell().Row(1).Column(7).Element(Block).Text("T").FontSize(fontSize);
            table.Cell().Row(1).Column(8).Element(Block).Text("W").FontSize(fontSize);
            table.Cell().Row(1).Column(9).Element(Block).Text("I").FontSize(fontSize);
            table.Cell().Row(1).Column(10).Element(Block).Text("A").FontSize(fontSize);
            table.Cell().Row(1).Column(11).Element(Block).Text("Ld").FontSize(fontSize);
            table.Cell().Row(1).Column(12).Element(Block).Text("Sv").FontSize(fontSize);
            table.Cell().Row(1).Column(13).Element(Block).Text("WSv").FontSize(fontSize);
            table.Cell().Row(1).Column(14).Element(Block).Text("Cp").FontSize(fontSize);
            table.Cell().Row(1).Column(15).Element(Block).Text("Dp").FontSize(fontSize);
            table.Cell().Row(1).Column(16).Element(Block).Text("US").FontSize(fontSize);
            table.Cell().Row(1).Column(17).Element(Block).Text("Cost").FontSize(fontSize);

            //uint RowIterator = 2;
            //foreach (var character in owbImportModel.characters)
            //{
            //    table.Cell().Row(RowIterator).Column(1).Element(Block).Text(character.name_en).FontSize(fontSize);
            //    table.Cell().Row(RowIterator).Column(2).Element(Block).Text(1).FontSize(fontSize);
            //}

            static IContainer Block(IContainer container)
            {
                return container
                    .Border(1)
                    .Background(Colors.Grey.Lighten3)
                    .ShowOnce()
                    //.MinWidth(50)
                    //.MinHeight(50)
                    .AlignCenter()
                    .AlignMiddle();
            }
        });

        page.Footer()
            .AlignCenter()
            .Text(x =>
            {
                x.Span("Page ");
                x.CurrentPageNumber();
            });
    });
})
.ShowInPreviewer();