using ClashBard.Tow.DataAccess;
using ClashBard.Tow.Models.Interfaces;
using ClashBard.Tow.Pdf;
using ClashBard.Tow.Pdf.Console;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

IConfiguration configuration = builder.Build();

var services = new ServiceCollection();
services.AddDbContext<TowDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("ClashBardConnection")));
services.AddTransient<SampleArmyList>();
//services.AddTransient<DarkElvesRepository>();
//services.AddTransient<IFactionsListRepository, FactionsListRepository>();
//services.AddTransient<IWeaponsRepository, WeaponsRepository>();
//services.AddTransient<IArmorsRepository, ArmorsRepository>();
//services.AddTransient<ISpecialRulesRepository, SpecialRulesRepository>();

//QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

var serviceProvider = services.BuildServiceProvider();

var sampleArmyList = serviceProvider.GetService<SampleArmyList>();

var army = sampleArmyList.GetVnDarkElfArmy();

PdfPrinter pdfPrinter = new();

pdfPrinter.PreviewArmy(army);