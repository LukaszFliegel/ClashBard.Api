using ClashBard.Tow.Models;
using ClashBard.Tow.Models.ArmyComposition;
using ClashBard.Tow.Models.MagicItems.MagicArmours;
using ClashBard.Tow.Models.SpecialRules.Interfaces;
using ClashBard.Tow.StaticData;
using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClashBard.Tow.Pdf;

public class PdfPrinter
{
    public PdfPrinter()
    {
        QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
    }

    public void PreviewArmy(TowArmy army)
    {
        Document.Create(container =>
        {

            float fontSize = 10;
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(12, Unit.Point);

                page.Header().Border(0).Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(1);
                        columns.RelativeColumn(1);
                    });

                    table.Cell().Row(1).Column(1).Element(DefaultCellContainer).Text(army.FactionName).FontSize(fontSize);
                    table.Cell().Row(1).Column(2).Element(DefaultCellContainer).Text($"{army.GetTotalPoints().ToString()}/{army.ArmyPoints} points").FontSize(fontSize);

                    PrintSeparatorLine(table, 1);
                });

                page.Content().Column(column =>
                {
                    uint RowIterator = 1;

                    column.Item().ShowEntire().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(1);
                            columns.RelativeColumn(1);
                            columns.RelativeColumn(1);
                            columns.RelativeColumn(1);
                            columns.RelativeColumn(1);
                        });

                        table.Cell().Row(RowIterator).Column(1).Element(Block).Text("Deployments").FontSize(fontSize);
                        table.Cell().Row(RowIterator).Column(2).Element(Block).Text("Vanguards").FontSize(fontSize);
                        table.Cell().Row(RowIterator).Column(3).Element(Block).Text("Ambushers").FontSize(fontSize);
                        table.Cell().Row(RowIterator).Column(4).Element(Block).Text("Total magic lvl").FontSize(fontSize);
                        table.Cell().Row(RowIterator).Column(5).Element(Block).Text("Total Unit Strength").FontSize(fontSize);

                        RowIterator++;
                        table.Cell().Row(RowIterator).Column(1).Element(DefaultCellContainer).Text(army.GetNumberOfDeploymentsString()).FontSize(fontSize);
                        table.Cell().Row(RowIterator).Column(2).Element(DefaultCellContainer).Text(army.GetNumberOfVanguards().ToString()).FontSize(fontSize);
                        table.Cell().Row(RowIterator).Column(3).Element(DefaultCellContainer).Text(army.GetNumberOfAmbushers().ToString()).FontSize(fontSize);
                        table.Cell().Row(RowIterator).Column(4).Element(DefaultCellContainer).Text(army.GetMagicLvlString()).FontSize(fontSize);
                        table.Cell().Row(RowIterator).Column(5).Element(DefaultCellContainer).Text(army.GetTotalUnitStrength().ToString()).FontSize(fontSize);
                        RowIterator = PrintSeparatorLine(table, RowIterator);
                    });


                    foreach (var character in army.GetCharacters())
                    {
                        column.Item().ShowEntire().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                UnitPanelColumnDefinition(columns);
                            });
                            PrintCharacterPanel(table, fontSize, ref RowIterator, character);
                        });
                    }

                    foreach (var unit in army.GetUnits())
                    {
                        column.Item().ShowEntire().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                UnitPanelColumnDefinition(columns);
                            });

                            PrintUnitPanel(table, fontSize, ref RowIterator, unit);
                        });
                    }

                    column.Item().ShowEntire().Table(table =>
                    {
                        RowIterator = 1;
                        RowIterator = PrintSeparatorLine(table, RowIterator);
                        RowIterator = PrintSeparatorLine(table, RowIterator);
                        RowIterator = PrintSeparatorLine(table, RowIterator);

                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(1);
                        });

                        table.Cell().Row(RowIterator).Column(1).Element(Block).Text("Army validation").FontSize(fontSize);
                    });

                    column.Item().ShowEntire().Table(table =>
                    {
                        RowIterator = 1;
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(1);
                            columns.RelativeColumn(2);
                        });

                        table.Cell().Row(RowIterator).Column(1).Element(Block).Text("Unit").FontSize(fontSize);
                        table.Cell().Row(RowIterator).Column(2).Element(Block).Text($"Validation error").FontSize(fontSize);
                        RowIterator++;

                        //PrintSeparatorLine(table, 1);

                        foreach (var validationError in army.Validate().ToList())
                        {

                            //column.Item().ShowEntire().Table(table =>
                            //{
                            //    table.ColumnsDefinition(columns =>
                            //    {
                            //        columns.RelativeColumn(1);
                            //    });
                            //    table.Cell().Row(RowIterator).Column(1).Element(DefaultCellContainer).Text(validationError.ValidationErrorMessage).FontSize(fontSize).Italic();
                            //});
                            table.Cell().Row(RowIterator).Column(1).Element(DefaultCellContainer).Text(validationError.Owner).FontSize(fontSize);
                            table.Cell().Row(RowIterator).Column(2).Element(DefaultCellContainer).Text(validationError.ValidationErrorMessage).FontSize(fontSize);
                            RowIterator++;
                        }
                    });


                });

                page.Footer()
                    .AlignCenter()
                    .Text(x =>
                    {
                        //x.Span("Page ");
                        //x.CurrentPageNumber();
                    });
            });
        })
        //.GeneratePdfAndShow();
        .ShowInCompanion();

    }

    // good for preview
    static Color darkerTone = Colors.Grey.Lighten1;
    static Color lightenTone = Colors.Grey.Lighten3;

    // good for printing
    //static Color darkerTone = Colors.Grey.Medium;
    //static Color lightenTone = Colors.Grey.Lighten1;

    static int indentation = 16;

    private static uint PrintSeparatorLine(TableDescriptor table, uint RowIterator)
    {
        RowIterator++;
        table.Cell().Row(RowIterator++).Element(HorizontalLine);
        return RowIterator;
    }

    private static void UnitPanelColumnDefinition(TableColumnsDefinitionDescriptor columns)
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
        columns.RelativeColumn(2);
    }

    private static void PrintCharacterPanel(TableDescriptor table, float fontSize, ref uint RowIterator, TowCharacter character)
    {
        PrintUnitHeaderRow(table, fontSize, RowIterator);
        RowIterator++;

        PrintModelRow(table, fontSize, RowIterator, 1, character);
        table.Cell().Row(RowIterator).Column(14).Element(DefaultCellContainer).Text(character.UnitStrength().ToString()).FontSize(fontSize);
        table.Cell().Row(RowIterator).Column(15).Element(DefaultCellContainer).Text(character.CalculateTotalCost().ToString()).FontSize(fontSize);

        if(character is TowCharacterMage mage)
        {
            RowIterator++;
            table.Cell().Row(RowIterator).Column(1).Element(DefaultCellContainer).Text($"Level {mage.MagicLevel.ToString()}").FontSize(fontSize);
            table.Cell().Row(RowIterator).Column(2).ColumnSpan(13).Element(DefaultCellContainer).Text($"{mage.GetMagicLore()}").FontSize(fontSize);
        }

        // print magic weapons
        foreach (var magicItem in character.GetMagicItems().Where(p => p.TowMagicItemCategory == Models.TowTypes.TowMagicItemCategory.MagicWeapon))
        {
            RowIterator++;
            PrintMagicWeaponItemRow(table, fontSize, RowIterator, magicItem);
        }

        foreach (var weapon in character.GetWeapons())
        {
            RowIterator++;
            PrintWeapon(table, fontSize, RowIterator, weapon);
        }

        // print all "print as a weapon" magic items
        foreach (var magicItem in character.GetMagicItems().Where(p => p.TowMagicItemCategory == Models.TowTypes.TowMagicItemCategory.FactionSpecificPrintAsWeapon))
        {
            RowIterator++;
            PrintMagicItemRow(table, fontSize, RowIterator, magicItem);
        }

        if (character.Mount != null)
        {
            RowIterator++;
            PrintCharacterMountRow(table, fontSize, RowIterator, 1, character.Mount);

            table.Cell().Row(RowIterator).Column(15).Element(DefaultCellContainer).Text($"[{character.Mount.PointCost}]").FontSize(fontSize).Italic();

            foreach (var weapon in character.Mount.GetWeapons())
            {
                RowIterator++;
                PrintWeapon(table, fontSize, RowIterator, weapon);
            }

            // print all "print as a weapon" magic items
            foreach (var magicItem in character.Mount.GetMagicItems().Where(p => p.TowMagicItemCategory == Models.TowTypes.TowMagicItemCategory.FactionSpecificPrintAsWeapon))
            {
                RowIterator++;
                PrintMagicItemRow(table, fontSize, RowIterator, magicItem);
            }

            var groupedCrewMembers = character.Mount.Crew
                .GroupBy(crew => crew.ModelType)
                .Select(group => new
                {
                    ModelType = group.Key,
                    Count = group.Count(),
                    CrewMember = group.First()
                })
                .ToList();

            foreach (var crew in groupedCrewMembers)
            {
                RowIterator++;
                PrintAdditialModelRow(table, fontSize, RowIterator, crew.Count, crew.CrewMember);

                foreach (var weapon in crew.CrewMember.GetWeapons())
                {
                    RowIterator++;
                    PrintWeapon(table, fontSize, RowIterator, weapon);
                }
            }
        }

        // print all non-weapon magic items (and all non "print as a weapon" magic items)
        foreach (var magicItem in character.GetMagicItems().Where(p => p.TowMagicItemCategory != Models.TowTypes.TowMagicItemCategory.MagicWeapon && p.TowMagicItemCategory != Models.TowTypes.TowMagicItemCategory.FactionSpecificPrintAsWeapon))
        {
            RowIterator++;
            PrintMagicItemRow(table, fontSize, RowIterator, magicItem);
        }

        RowIterator++;
        PrintCharacterFormattedRules(table, fontSize, RowIterator, character);

        //RowIterator++;
        //PrintCharacterRules(table, fontSize, RowIterator, character);

        //RowIterator++;
        //table.Cell().RowSpan(RowIterator).ColumnSpan(15).LineHorizontal(8, Unit.Point);
        //table.ExtendLastCellsToTableBottom();
        RowIterator = PrintSeparatorLine(table, RowIterator);
    }

    private static void PrintUnitPanel(TableDescriptor table, float fontSize, ref uint RowIterator, TowUnit unit)
    {
        PrintUnitHeaderRow(table, fontSize, RowIterator);
        RowIterator++;

        PrintModelRow(table, fontSize, RowIterator, unit.GetAmount(), unit.Model);

        table.Cell().Row(RowIterator).Column(14).Element(DefaultCellContainer).Text(unit.UnitStrength().ToString()).FontSize(fontSize);
        table.Cell().Row(RowIterator).Column(15).Element(DefaultCellContainer).Text(unit.CalculateTotalCost().ToString()).FontSize(fontSize);

        if (unit.HasChampion() && unit.Model.ChampionModel != null)
        {
            PrintChampionModelRow(table, fontSize, RowIterator + 1, unit.Model.ChampionModel);
            RowIterator++;
        }

        foreach (var weapon in unit.Model.GetWeapons())
        {
            RowIterator++;
            PrintWeapon(table, fontSize, RowIterator, weapon);
        }

        if (unit.Model.Mount != null)
        {
            RowIterator++;
            PrintUnitMountRow(table, fontSize, RowIterator, unit.GetAmount(), unit.Model.Mount);

            //table.Cell().Row(RowIterator).Column(15).Element(DefaultCellContainer).Text($"[{unit.Model.Mount.PointCost}]").FontSize(fontSize).Italic();

            //foreach (var weapon in unit.Model.Mount.GetWeapons())
            //{
            //    RowIterator++;
            //    PrintWeapon(table, fontSize, RowIterator, weapon);
            //}
        }

        if (unit.HasMagicBanner())
        {
            PrintMagicItemRow(table, fontSize, RowIterator + 1, unit.GetMagicStandard());
            RowIterator++;
        }

        //var groupedCrewMembers = unit.Model.Crew.GroupBy(p => p.ModelType) // how to group them?

        var groupedCrewMembers = unit.Model.Crew
            .GroupBy(crew => crew.ModelType)
            .Select(group => new
            {
                ModelType = group.Key,
                Count = group.Count(),
                CrewMember = group.First()
            })
            .ToList();

        foreach (var crew in groupedCrewMembers)
        {
            RowIterator++;
            PrintAdditialModelRow(table, fontSize, RowIterator, crew.Count, crew.CrewMember);

            foreach (var weapon in crew.CrewMember.GetWeapons())
            {
                RowIterator++;
                PrintWeapon(table, fontSize, RowIterator, weapon);
            }
        }

        PrintUnitFormattedRules(table, fontSize, RowIterator + 1, unit);
        RowIterator++;

        //PrintUnitRules(table, fontSize, RowIterator + 1, unit);
        //RowIterator++;

        //RowIterator++;

        //table.Cell().RowSpan(RowIterator).ColumnSpan(15).LineHorizontal(8, Unit.Point);
        //table.ExtendLastCellsToTableBottom();
        RowIterator = PrintSeparatorLine(table, RowIterator);
    }

    private static void PrintUnitHeaderRow(TableDescriptor table, float fontSize, uint rowNumber)
    {
        table.Cell().Row(rowNumber).Column(1).Element(Block).Text("Unit name").FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(2).Element(Block).Text("#").FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(3).Element(Block).Text("M").FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(4).Element(Block).Text("WS").FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(5).Element(Block).Text("BS").FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(6).Element(Block).Text("S").FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(7).Element(Block).Text("T").FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(8).Element(Block).Text("W").FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(9).Element(Block).Text("I").FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(10).Element(Block).Text("A").FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(11).Element(Block).Text("Ld").FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(12).Element(Block).Text("Sv").FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(13).Element(Block).Text("WSv").FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(14).Element(Block).Text("US").FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(15).Element(Block).Text("Cost").FontSize(fontSize);
    }

    static IContainer Block(IContainer container)
    {
        return container
            .Border(1)
            .Background(darkerTone)
            .ShowOnce()
            .AlignCenter()
            .AlignMiddle()
            .ShowEntire();
    }

    static IContainer DefaultCellContainer(IContainer container)
    {
        return container
            .Border(1)
            .Background(lightenTone)
            .Padding(1)
            .ShowOnce()
            .AlignCenter()
            .AlignMiddle();
    }

    

    static IContainer DefaultCellWithIndentationContainer(IContainer container)
    {
        return container
            .Border(1)
            .Background(lightenTone)
            .Padding(1)
            .ShowOnce()
            .AlignLeft()
            .PaddingLeft(indentation, Unit.Point)
            .AlignMiddle()
            .ShowEntire();
    }

    static IContainer DefaultCellWithDoubleIndentationContainer(IContainer container)
    {
        return container
            .Border(1)
            .Background(lightenTone)
            .ShowOnce()
            .AlignLeft()
            .PaddingLeft(2* indentation, Unit.Point)
            .AlignMiddle()
            .ShowEntire();
    }

    static IContainer DefaultCellContainerLeftAligned(IContainer container)
    {
        return container
            .Border(1)
            .Background(lightenTone)
            .Padding(1)
            .ShowOnce()
            .AlignLeft()
            .AlignMiddle()
            .ShowEntire();
    }

    static IContainer HorizontalLine(IContainer container)
    {
        return container
            .PaddingBottom(8)
            .Background(darkerTone)
            .BorderHorizontal(0)
            .ShowOnce();
    }

    static void PrintModelRow(TableDescriptor table, float fontSize, uint rowNumber, int? unitAmount, TowModel model)
    {
        table.Cell().Row(rowNumber).Column(1).Element(DefaultCellContainerLeftAligned).Text(model.ModelType.ToNameString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(2).Element(DefaultCellContainer).Text(unitAmount.HasValue ? unitAmount.ToString() : string.Empty).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(3).Element(DefaultCellContainer).Text(model.Mount == null ? model.Movement.ToString() : "-").FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(4).Element(DefaultCellContainer).Text(model.WeaponSkill.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(5).Element(DefaultCellContainer).Text(model.BallisticSkill.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(6).Element(DefaultCellContainer).Text(model.Strength.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(7).Element(DefaultCellContainer).Text(model.Toughness.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(8).Element(DefaultCellContainer).Text(model.Wounds.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(9).Element(DefaultCellContainer).Text(model.Initiative.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(10).Element(DefaultCellContainer).Text(model.Attacks.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(11).Element(DefaultCellContainer).Text(model.Leadership.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(12).Element(DefaultCellContainer).Text($"{model.GetSaveString()}").FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(13).Element(DefaultCellContainer).Text($"{model.GetWardSaveString()}").FontSize(fontSize);
    }

    static void PrintAdditialModelRow(TableDescriptor table, float fontSize, uint rowNumber, int? unitAmount, TowModelAdditional model)
    {
        table.Cell().Row(rowNumber).Column(1).Element(DefaultCellWithIndentationContainer).Text(model.ModelType.ToNameString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(2).Element(DefaultCellContainer).Text(unitAmount.HasValue ? unitAmount.ToString() : string.Empty).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(3).Element(DefaultCellContainer).Text(model.Movement.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(4).Element(DefaultCellContainer).Text(model.WeaponSkill.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(5).Element(DefaultCellContainer).Text(model.BallisticSkill.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(6).Element(DefaultCellContainer).Text(model.Strength.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(7).Element(DefaultCellContainer).Text(model.Toughness.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(8).Element(DefaultCellContainer).Text(model.Wounds.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(9).Element(DefaultCellContainer).Text(model.Initiative.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(10).Element(DefaultCellContainer).Text(model.Attacks.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(11).Element(DefaultCellContainer).Text(model.Leadership.ToString()).FontSize(fontSize);
    }

    static void PrintCharacterMountRow(TableDescriptor table, float fontSize, uint rowNumber, int? unitAmount, TowModelCharacterMount model)
    {
        string toughnessString = model.ToughnessAdded.HasValue ?
            $"+{model.ToughnessAdded}" :
            model.Toughness.HasValue ? model.Toughness.Value.ToString() : string.Empty;

        string woundsstring = model.WoundsAdded.HasValue ?
            $"+{model.WoundsAdded}" :
            model.Wounds.HasValue ? model.Wounds.Value.ToString() : string.Empty;

        table.Cell().Row(rowNumber).Column(1).Element(DefaultCellContainerLeftAligned).Text(model.ModelMountType.ToNameString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(2).Element(DefaultCellContainer).Text(unitAmount.HasValue ? unitAmount.ToString() : string.Empty).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(3).Element(DefaultCellContainer).Text(model.Movement.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(4).Element(DefaultCellContainer).Text(model.WeaponSkill.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(5).Element(DefaultCellContainer).Text(model.BallisticSkill.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(6).Element(DefaultCellContainer).Text(model.Strength.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(7).Element(DefaultCellContainer).Text(toughnessString).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(8).Element(DefaultCellContainer).Text(woundsstring).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(9).Element(DefaultCellContainer).Text(model.Initiative.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(10).Element(DefaultCellContainer).Text(model.Attacks.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(11).Element(DefaultCellContainer).Text(model.Leadership.ToString()).FontSize(fontSize);
    }

    static void PrintUnitMountRow(TableDescriptor table, float fontSize, uint rowNumber, int? unitAmount, TowModelMount model)
    {
        table.Cell().Row(rowNumber).Column(1).Element(DefaultCellContainerLeftAligned).Text(model.ModelMountType.ToNameString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(2).Element(DefaultCellContainer).Text(unitAmount.HasValue ? unitAmount.ToString() : string.Empty).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(3).Element(DefaultCellContainer).Text(model.Movement.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(4).Element(DefaultCellContainer).Text(model.WeaponSkill.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(5).Element(DefaultCellContainer).Text(model.BallisticSkill.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(6).Element(DefaultCellContainer).Text(model.Strength.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(7).Element(DefaultCellContainer).Text(string.Empty).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(8).Element(DefaultCellContainer).Text(string.Empty).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(9).Element(DefaultCellContainer).Text(model.Initiative.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(10).Element(DefaultCellContainer).Text(model.Attacks.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(11).Element(DefaultCellContainer).Text(model.Leadership.ToString()).FontSize(fontSize);
    }

    static void PrintUnitFormattedRules(TableDescriptor table, float fontSize, uint rowNumber, TowUnit unit)
    {
        var separator = ClashBardStatic.Separator;

        table.Cell().Row(rowNumber).Column(2).ColumnSpan(14).Element(DefaultCellContainer).Text(text =>
        {
            var atLeastOneArmorPrinted = false;
            foreach (var armor in unit.Model.GetArmoursToPrint())
            {
                text.Span($"{armor.ArmorType.ToNameString()}").FontSize(fontSize).Bold();
                text.Span(separator).FontSize(fontSize);

                atLeastOneArmorPrinted = true;
            }

            if (atLeastOneArmorPrinted)
            {
                text.EmptyLine();
            }

            foreach (var rule in unit.GetRulesDescriptions())
            {
                if (!string.IsNullOrEmpty(rule.Key))
                    text.Span($"{rule.Key}").FontSize(fontSize).Bold();

                if (!string.IsNullOrEmpty(rule.Key) && !string.IsNullOrEmpty(rule.Value))
                    text.Span(": ").FontSize(fontSize);

                if (!string.IsNullOrEmpty(rule.Value))
                    text.Span($"{rule.Value.Trim()}").FontSize(fontSize);

                text.Span(separator).FontSize(fontSize);
            }
        }
        );
    }

    static void PrintUnitRules(TableDescriptor table, float fontSize, uint rowNumber, TowUnit unit)
    {
        table.Cell().Row(rowNumber).Column(2).ColumnSpan(14).Element(DefaultCellContainer).Text(unit.GetRulesShortDescription()).FontSize(fontSize);
    }

    static void PrintCharacterFormattedRules(TableDescriptor table, float fontSize, uint rowNumber, TowCharacter character)
    {
        var separator = ClashBardStatic.Separator;

        table.Cell().Row(rowNumber).Column(2).ColumnSpan(14).Element(DefaultCellContainer).Text(text =>
        {
            var atLeastOneArmorPrinted = false;
            foreach (var armor in character.GetArmoursToPrint())
            {
                text.Span($"{armor.ArmorType.ToNameString()}").FontSize(fontSize).Bold();
                text.Span(separator).FontSize(fontSize);

                atLeastOneArmorPrinted = true;
            }

            if (atLeastOneArmorPrinted)
            {
                text.EmptyLine();
            }

            foreach (var rule in character.GetRulesDescriptions())
            {
                if (!string.IsNullOrEmpty(rule.Key))
                    text.Span($"{rule.Key}").FontSize(fontSize).Bold();

                if (!string.IsNullOrEmpty(rule.Key) && !string.IsNullOrEmpty(rule.Value))
                    text.Span(": ").FontSize(fontSize);

                if (!string.IsNullOrEmpty(rule.Value))
                    text.Span($"{rule.Value.Trim()}").FontSize(fontSize);

                text.Span(separator).FontSize(fontSize);
            }
        }
        );
    }

    static void PrintCharacterRules(TableDescriptor table, float fontSize, uint rowNumber, TowCharacter character)
    {
        table.Cell().Row(rowNumber).Column(2).ColumnSpan(14).Element(DefaultCellContainer).Text(character.GetRulesShortDescription()).FontSize(fontSize);
    }

    static void PrintChampionModelRow(TableDescriptor table, float fontSize, uint rowNumber, TowModel model)
    {
        table.Cell().Row(rowNumber).Column(1).Element(DefaultCellWithIndentationContainer).Text(model.ChampionName).FontSize(fontSize).Italic();
        table.Cell().Row(rowNumber).Column(2).Element(DefaultCellContainer).Text("[1]").FontSize(fontSize).Italic();
        table.Cell().Row(rowNumber).Column(3).Element(DefaultCellContainer).Text(model.Movement.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(4).Element(DefaultCellContainer).Text(model.WeaponSkill.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(5).Element(DefaultCellContainer).Text(model.BallisticSkill.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(6).Element(DefaultCellContainer).Text(model.Strength.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(7).Element(DefaultCellContainer).Text(model.Toughness.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(8).Element(DefaultCellContainer).Text(model.Wounds.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(9).Element(DefaultCellContainer).Text(model.Initiative.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(10).Element(DefaultCellContainer).Text(model.Attacks.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(11).Element(DefaultCellContainer).Text(model.Leadership.ToString()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(12).Element(DefaultCellContainer).Text($"{model.GetSaveString()}").FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(13).Element(DefaultCellContainer).Text($"{model.GetWardSaveString()}").FontSize(fontSize);

        table.Cell().Row(rowNumber).Column(15).Element(DefaultCellContainer).Text($"[{model.PointCost}]").FontSize(fontSize).Italic();
    }

    static void PrintMagicItemRow(TableDescriptor table, float fontSize, uint rowNumber, TowMagicItem magicItem)
    {
        if (magicItem is IExtremelyCommon extremelyCommonMagicItem && extremelyCommonMagicItem.NumberOfOccurences > 1)
        {
            table.Cell().Row(rowNumber).Column(1).Element(DefaultCellContainer).Text($"{magicItem.MagicItemType.ToNameString()} x{extremelyCommonMagicItem.NumberOfOccurences}").FontSize(fontSize).Italic();
        }
        else
        {
            table.Cell().Row(rowNumber).Column(1).Element(DefaultCellContainer).Text(magicItem.MagicItemType.ToNameString()).FontSize(fontSize).Italic();
        }
        table.Cell().Row(rowNumber).Column(2).ColumnSpan(13).Element(DefaultCellContainer).Text(magicItem.GetSpecialRulesShortDescription()).FontSize(fontSize);
        if (magicItem.Points > 0)
        {
            table.Cell().Row(rowNumber).Column(15).Element(DefaultCellContainer).Text($"[{magicItem.Points}]").FontSize(fontSize).Italic();
        }
    }

    static void PrintMagicWeaponItemRow(TableDescriptor table, float fontSize, uint rowNumber, TowMagicItem magicWeapon)
    {
        table.Cell().Row(rowNumber).Column(1).Element(DefaultCellWithDoubleIndentationContainer).Text(magicWeapon.MagicItemType.ToNameString()).FontSize(fontSize).Italic();
        table.Cell().Row(rowNumber).Column(2).ColumnSpan(13).Element(DefaultCellContainerLeftAligned).Text(magicWeapon.GetSpecialRulesShortDescription()).FontSize(fontSize);
        table.Cell().Row(rowNumber).Column(15).Element(DefaultCellContainer).Text($"[{magicWeapon.Points}]").FontSize(fontSize).Italic();
    }

    static void PrintWeapon(TableDescriptor table, float fontSize, uint rowNumber, TowWeapon weapon)
    {
        table.Cell().Row(rowNumber).Column(1).Element(DefaultCellWithDoubleIndentationContainer).Text(weapon.WeaponType.ToNameString()).FontSize(fontSize).Italic();
        table.Cell().Row(rowNumber).Column(2).ColumnSpan(13).Element(DefaultCellContainerLeftAligned).Text(weapon.GetSpecialRulesShortDescription()).FontSize(fontSize);
    }
}