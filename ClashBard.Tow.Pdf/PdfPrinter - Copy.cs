//using ClashBard.Tow.Models;
//using ClashBard.Tow.Models.MagicItems.MagicArmours;
//using ClashBard.Tow.StaticData;
//using QuestPDF.Companion;
//using QuestPDF.Fluent;
//using QuestPDF.Helpers;
//using QuestPDF.Infrastructure;
//using QuestPDF.Previewer;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace ClashBard.Tow.Pdf;

//public class PdfPrinter
//{
//    public PdfPrinter()
//    {
//        QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
//    }

//    public void PreviewArmy(TowArmy army)
//    {
//        Document.Create(container =>
//        {

//            float fontSize = 10;
//            container.Page(page =>
//            {
//                page.Size(PageSizes.A4);
//                page.Margin(12, Unit.Point);

//                page.Header().Border(0).Table(table =>
//                {
//                    table.ColumnsDefinition(columns =>
//                    {
//                        columns.RelativeColumn();
//                        columns.RelativeColumn();
//                    });


//                    table.Cell().Row(1).Column(1).Padding(4).AlignRight().Text($"{army.Points} Pts");
//                    table.Cell().Row(1).Column(2).Padding(4).AlignLeft().Text($"{army.Faction.FactionType} Roster");
//                });

//                page.Content().Border(0).Table(table =>
//                {
//                    table.ColumnsDefinition(columns =>
//                    {
//                        columns.RelativeColumn(8);
//                        columns.RelativeColumn(1);
//                        columns.RelativeColumn(1);
//                        columns.RelativeColumn(1);
//                        columns.RelativeColumn(1);
//                        columns.RelativeColumn(1);
//                        columns.RelativeColumn(1);
//                        columns.RelativeColumn(1);
//                        columns.RelativeColumn(1);
//                        columns.RelativeColumn(1);
//                        columns.RelativeColumn(1);
//                        columns.RelativeColumn(1);
//                        columns.RelativeColumn(1);
//                        columns.RelativeColumn(1);
//                        columns.RelativeColumn(2);
//                    });

//                    uint RowIterator = 1;

//                    foreach (var character in army.Characters)
//                    {
//                        PrintCharacterPanel(table, fontSize, ref RowIterator, character);
//                    }


//                    foreach (var unit in army.Units)
//                    {
//                        PrintUnitPanel(table, fontSize, ref RowIterator, unit);
//                    }


//                });

//                page.Footer()
//                    .AlignCenter()
//                    .Text(x =>
//                    {
//                        //x.Span("Page ");
//                        //x.CurrentPageNumber();
//                    });
//            });
//        })
//        .ShowInCompanion();

//    }

//    private static void PrintCharacterPanel(TableDescriptor table, float fontSize, ref uint RowIterator, TowCharacter character)
//    {
//        PrintUnitHeaderRow(table, fontSize, RowIterator);
//        RowIterator++;

//        PrintModelRow(table, fontSize, RowIterator, 1, character);
//        table.Cell().Row(RowIterator).Column(14).Element(DefaultCellContainer).Text(character.UnitStrength().ToString()).FontSize(fontSize);
//        table.Cell().Row(RowIterator).Column(15).Element(DefaultCellContainer).Text(character.CalculateTotalCost().ToString()).FontSize(fontSize);

//        // print magic weapons
//        foreach (var magicItem in character.MagicItems.Where(p => p.TowMagicItemCategory == Models.TowTypes.TowMagicItemCategory.MagicWeapon))
//        {
//            RowIterator++;
//            PrintMagicItemRow(table, fontSize, RowIterator, magicItem);
//        }

//        foreach (var weapon in character.GetWeapons())
//        {
//            RowIterator++;
//            PrintWeapon(table, fontSize, RowIterator, weapon);
//        }

//        if (character.Mount != null)
//        {
//            RowIterator++;
//            PrintMountRow(table, fontSize, RowIterator, 1, character.Mount);

//            table.Cell().Row(RowIterator).Column(15).Element(DefaultCellContainer).Text($"[{character.Mount.PointCost}]").FontSize(fontSize).Italic();

//            foreach (var weapon in character.Mount.GetWeapons())
//            {
//                RowIterator++;
//                PrintWeapon(table, fontSize, RowIterator, weapon);
//            }
//        }

//        // print all non-weapon magic items
//        foreach (var magicItem in character.MagicItems.Where(p => p.TowMagicItemCategory != Models.TowTypes.TowMagicItemCategory.MagicWeapon))
//        {
//            RowIterator++;
//            PrintMagicItemRow(table, fontSize, RowIterator, magicItem);
//        }

//        PrintCharacterRules(table, fontSize, RowIterator + 1, character);
//        RowIterator++;
//        //RowIterator++;
//        //table.Cell().RowSpan(RowIterator).ColumnSpan(15).LineHorizontal(8, Unit.Point);
//        //table.ExtendLastCellsToTableBottom();
//        RowIterator++;
//        //table.Footer(table => table.
//        table.Cell().Row(RowIterator++).Element(HorizontalLine);
//    }

//    private static void PrintUnitPanel(TableDescriptor table, float fontSize, ref uint RowIterator, TowUnit unit)
//    {
//        PrintUnitHeaderRow(table, fontSize, RowIterator);
//        RowIterator++;

//        PrintModelRow(table, fontSize, RowIterator, unit.GetAmount(), unit.Model);

//        table.Cell().Row(RowIterator).Column(14).Element(DefaultCellContainer).Text(unit.UnitStrength().ToString()).FontSize(fontSize);
//        table.Cell().Row(RowIterator).Column(15).Element(DefaultCellContainer).Text(unit.CalculateTotalCost().ToString()).FontSize(fontSize);

//        foreach (var weapon in unit.Model.GetWeapons())
//        {
//            RowIterator++;
//            PrintWeapon(table, fontSize, RowIterator, weapon);
//        }

//        if (unit.HasChampion() && unit.Model.ChampionModel != null)
//        {
//            PrintChampionModelRow(table, fontSize, RowIterator + 1, unit.Model.ChampionModel);
//            RowIterator++;
//        }

//        if (unit.HasMagicBanner())
//        {
//            PrintMagicItemRow(table, fontSize, RowIterator + 1, unit.GetMagicBanner());
//            RowIterator++;
//        }


//        //var groupedCrewMembers = unit.Model.Crew.GroupBy(p => p.ModelType) // how to group them?

//        var groupedCrewMembers = unit.Model.Crew
//            .GroupBy(crew => crew.ModelType)
//            .Select(group => new
//            {
//                ModelType = group.Key,
//                Count = group.Count(),
//                CrewMember = group.First()
//            })
//            .ToList();

//        foreach (var crew in groupedCrewMembers)
//        {
//            RowIterator++;
//            PrintAdditialModelRow(table, fontSize, RowIterator, crew.Count, crew.CrewMember);

//            foreach (var weapon in crew.CrewMember.GetWeapons())
//            {
//                RowIterator++;
//                PrintWeapon(table, fontSize, RowIterator, weapon);
//            }
//        }

//        PrintUnitRules(table, fontSize, RowIterator + 1, unit);
//        RowIterator++;

//        //RowIterator++;

//        //table.Cell().RowSpan(RowIterator).ColumnSpan(15).LineHorizontal(8, Unit.Point);
//        //table.ExtendLastCellsToTableBottom();
//        RowIterator++;
//        //table.Footer(table => table.
//        table.Cell().Row(RowIterator++).Element(HorizontalLine);
//    }

//    private static void PrintUnitHeaderRow(TableDescriptor table, float fontSize, uint rowNumber)
//    {
//        table.Cell().Row(rowNumber).Column(1).Element(Block).Text("Unit name").FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(2).Element(Block).Text("#").FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(3).Element(Block).Text("M").FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(4).Element(Block).Text("WS").FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(5).Element(Block).Text("BS").FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(6).Element(Block).Text("S").FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(7).Element(Block).Text("T").FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(8).Element(Block).Text("W").FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(9).Element(Block).Text("I").FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(10).Element(Block).Text("A").FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(11).Element(Block).Text("Ld").FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(12).Element(Block).Text("Sv").FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(13).Element(Block).Text("WSv").FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(14).Element(Block).Text("US").FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(15).Element(Block).Text("Cost").FontSize(fontSize);
//    }

//    static IContainer Block(IContainer container)
//    {
//        return container
//            .Border(1)
//            .Background(Colors.Grey.Lighten2)
//            .ShowOnce()
//            .AlignCenter()
//            .AlignMiddle()
//            .ShowEntire();
//    }

//    static IContainer DefaultCellContainer(IContainer container)
//    {
//        return container
//            .Border(1)
//            .Background(Colors.Grey.Lighten4)
//            .ShowOnce()
//            .AlignCenter()
//            .AlignMiddle()
//            .ShowEntire();
//    }

//    static IContainer DefaultCellWithIndentationContainer(IContainer container)
//    {
//        return container
//            .Border(1)
//            .Background(Colors.Grey.Lighten4)
//            .ShowOnce()
//            .AlignLeft()
//            .PaddingLeft(16, Unit.Point)
//            .AlignMiddle()
//            .ShowEntire();
//    }

//    static IContainer UnitName(IContainer container)
//    {
//        return container
//            .Border(1)
//            .Background(Colors.Grey.Lighten4)
//            .ShowOnce()
//            .AlignLeft()
//            .AlignMiddle()
//            .ShowEntire();
//    }

//    static IContainer HorizontalLine(IContainer container)
//    {
//        return container
//            .PaddingBottom(8)
//            .Background(Colors.Grey.Lighten2)
//            .BorderHorizontal(0)
//            .ShowOnce();
//    }

//    static void PrintModelRow(TableDescriptor table, float fontSize, uint rowNumber, int? unitAmount, TowModel model)
//    {
//        table.Cell().Row(rowNumber).Column(1).Element(UnitName).Text(model.ModelType.ToDescriptionString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(2).Element(DefaultCellContainer).Text(unitAmount.HasValue ? unitAmount.ToString() : string.Empty).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(3).Element(DefaultCellContainer).Text(model.Movement.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(4).Element(DefaultCellContainer).Text(model.WeaponSkill.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(5).Element(DefaultCellContainer).Text(model.BallisticSkill.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(6).Element(DefaultCellContainer).Text(model.Strength.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(7).Element(DefaultCellContainer).Text(model.Toughness.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(8).Element(DefaultCellContainer).Text(model.Wounds.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(9).Element(DefaultCellContainer).Text(model.Initiative.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(10).Element(DefaultCellContainer).Text(model.Attacks.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(11).Element(DefaultCellContainer).Text(model.Leadership.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(12).Element(DefaultCellContainer).Text($"{model.GetSaveString()}").FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(13).Element(DefaultCellContainer).Text($"{model.GetWardSaveString()}").FontSize(fontSize);
//    }

//    static void PrintAdditialModelRow(TableDescriptor table, float fontSize, uint rowNumber, int? unitAmount, TowModelAdditional model)
//    {
//        table.Cell().Row(rowNumber).Column(1).Element(DefaultCellWithIndentationContainer).Text(model.ModelType.ToDescriptionString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(2).Element(DefaultCellContainer).Text(unitAmount.HasValue ? unitAmount.ToString() : string.Empty).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(3).Element(DefaultCellContainer).Text(model.Movement.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(4).Element(DefaultCellContainer).Text(model.WeaponSkill.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(5).Element(DefaultCellContainer).Text(model.BallisticSkill.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(6).Element(DefaultCellContainer).Text(model.Strength.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(7).Element(DefaultCellContainer).Text(model.Toughness.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(8).Element(DefaultCellContainer).Text(model.Wounds.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(9).Element(DefaultCellContainer).Text(model.Initiative.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(10).Element(DefaultCellContainer).Text(model.Attacks.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(11).Element(DefaultCellContainer).Text(model.Leadership.ToString()).FontSize(fontSize);
//    }

//    static void PrintMountRow(TableDescriptor table, float fontSize, uint rowNumber, int? unitAmount, TowModelMount model)
//    {
//        table.Cell().Row(rowNumber).Column(1).Element(UnitName).Text(model.ModelMountType.ToDescriptionString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(2).Element(DefaultCellContainer).Text(unitAmount.HasValue ? unitAmount.ToString() : string.Empty).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(3).Element(DefaultCellContainer).Text(model.Movement.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(4).Element(DefaultCellContainer).Text(model.WeaponSkill.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(5).Element(DefaultCellContainer).Text(model.BallisticSkill.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(6).Element(DefaultCellContainer).Text(model.Strength.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(7).Element(DefaultCellContainer).Text($"+{model.ToughnessAdded}").FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(8).Element(DefaultCellContainer).Text($"+{model.WoundsAdded}").FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(9).Element(DefaultCellContainer).Text(model.Initiative.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(10).Element(DefaultCellContainer).Text(model.Attacks.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(11).Element(DefaultCellContainer).Text(model.Leadership.ToString()).FontSize(fontSize);
//    }

//    static void PrintUnitRules(TableDescriptor table, float fontSize, uint rowNumber, TowUnit unit)
//    {
//        table.Cell().Row(rowNumber).Column(2).ColumnSpan(14).Element(DefaultCellContainer).Text(unit.GetRulesShortDescription()).FontSize(fontSize);
//    }

//    static void PrintCharacterRules(TableDescriptor table, float fontSize, uint rowNumber, TowCharacter character)
//    {
//        table.Cell().Row(rowNumber).Column(2).ColumnSpan(14).Element(DefaultCellContainer).Text(character.GetRulesShortDescription()).FontSize(fontSize);
//    }

//    static void PrintChampionModelRow(TableDescriptor table, float fontSize, uint rowNumber, TowModel model)
//    {
//        table.Cell().Row(rowNumber).Column(1).Element(DefaultCellWithIndentationContainer).Text(model.ChampionName).FontSize(fontSize).Italic();
//        table.Cell().Row(rowNumber).Column(2).Element(DefaultCellContainer).Text("1").FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(3).Element(DefaultCellContainer).Text(model.Movement.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(4).Element(DefaultCellContainer).Text(model.WeaponSkill.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(5).Element(DefaultCellContainer).Text(model.BallisticSkill.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(6).Element(DefaultCellContainer).Text(model.Strength.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(7).Element(DefaultCellContainer).Text(model.Toughness.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(8).Element(DefaultCellContainer).Text(model.Wounds.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(9).Element(DefaultCellContainer).Text(model.Initiative.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(10).Element(DefaultCellContainer).Text(model.Attacks.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(11).Element(DefaultCellContainer).Text(model.Leadership.ToString()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(12).Element(DefaultCellContainer).Text($"{model.GetSaveString()}").FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(13).Element(DefaultCellContainer).Text($"{model.GetWardSaveString()}").FontSize(fontSize);

//        table.Cell().Row(rowNumber).Column(15).Element(DefaultCellContainer).Text($"[{model.PointCost}]").FontSize(fontSize).Italic();
//    }

//    static void PrintMagicItemRow(TableDescriptor table, float fontSize, uint rowNumber, TowMagicItem banner)
//    {
//        table.Cell().Row(rowNumber).Column(1).Element(DefaultCellWithIndentationContainer).Text(banner.MagicItemType.ToDescriptionString()).FontSize(fontSize).Italic();
//        table.Cell().Row(rowNumber).Column(2).ColumnSpan(13).Element(DefaultCellContainer).Text(banner.GetSpecialRulesShortDescription()).FontSize(fontSize);
//        table.Cell().Row(rowNumber).Column(15).Element(DefaultCellContainer).Text($"[{banner.Points}]").FontSize(fontSize).Italic();
//    }

//    static void PrintWeapon(TableDescriptor table, float fontSize, uint rowNumber, TowWeapon weapon)
//    {
//        table.Cell().Row(rowNumber).Column(1).Element(DefaultCellContainer).Text(weapon.WeaponType.ToDescriptionString()).FontSize(fontSize).Italic();
//        table.Cell().Row(rowNumber).Column(2).ColumnSpan(13).Element(DefaultCellContainer).Text(weapon.GetSpecialRulesShortDescription()).FontSize(fontSize);
//    }

//}