using ClashBard.Tow.Models;
using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using System;
using System.Collections.Generic;
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
                    //columns.RelativeColumn(1);
                    //columns.RelativeColumn(1);
                    columns.RelativeColumn(2);
                });

                table.Cell().Row(1).Column(1).Element(Block).Text("Unit name").FontSize(fontSize);
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
                //table.Cell().Row(1).Column(14).Element(Block).Text("Cp").FontSize(fontSize);
                //table.Cell().Row(1).Column(15).Element(Block).Text("Dp").FontSize(fontSize);
                table.Cell().Row(1).Column(14).Element(Block).Text("US").FontSize(fontSize);
                table.Cell().Row(1).Column(15).Element(Block).Text("Cost").FontSize(fontSize);

                //table.Cell().Row(1).Column(18).Element(Block).Text("aaaa").FontSize(fontSize);

                //uint RowIterator = 2;
                //foreach (var character in owbImportModel.characters)
                //{
                //    table.Cell().Row(RowIterator).Column(1).Element(Block).Text(character.name_en).FontSize(fontSize);
                //    table.Cell().Row(RowIterator).Column(2).Element(Block).Text(1).FontSize(fontSize);
                //}

                uint RowIterator = 2;
                foreach (var unit in army.Units)
                {
                    PrintModelRow(table, fontSize, RowIterator, unit.GetAmount(), unit.Model);

                    table.Cell().Row(RowIterator).Column(14).Element(UnitContainer).Text(unit.Model.ModelTroopType.UnitStrength() * unit.GetAmount()).FontSize(fontSize);
                    table.Cell().Row(RowIterator).Column(15).Element(UnitContainer).Text(unit.GetUnitCost()).FontSize(fontSize);                    

                    if (unit.HasChampion() && unit.Model.ChampionModel != null)
                    {
                        PrintChampionModelRow(table, fontSize, RowIterator + 1, unit.Model.ChampionModel);
                        RowIterator++;
                    }

                    if (unit.HasMagicBanner())
                    {
                        PrintMagicBannerRow(table, fontSize, RowIterator + 1, unit.GetMagicBanner());
                        RowIterator++;
                    }

                    PrintUnitRules(table, fontSize, RowIterator + 1, unit);
                    RowIterator++;

                    //RowIterator++;

                    //table.Cell().RowSpan(RowIterator).ColumnSpan(15).LineHorizontal(8, Unit.Point);
                    //table.ExtendLastCellsToTableBottom();
                    RowIterator++;
                    //table.Footer(table => table.
                    table.Cell().Row(RowIterator++).Element(HorizontalLine);
                }

                static IContainer HorizontalLine(IContainer container)
                {
                    return container
                        //.BorderBottom(8)
                        .PaddingBottom(8)

                        .Background(Colors.Grey.Lighten2)
                        .BorderHorizontal(0)
                        .ShowOnce();
                }

                static void PrintModelRow(TableDescriptor table, float fontSize, uint rowNumber, int? unitAmount, TowModel model)
                {
                    table.Cell().Row(rowNumber).Column(1).Element(UnitName).Text(model.ModelType.ToString()).FontSize(fontSize);
                    table.Cell().Row(rowNumber).Column(2).Element(UnitContainer).Text(unitAmount.HasValue ? unitAmount.ToString() : string.Empty).FontSize(fontSize);
                    table.Cell().Row(rowNumber).Column(3).Element(UnitContainer).Text(model.Movement).FontSize(fontSize);
                    table.Cell().Row(rowNumber).Column(4).Element(UnitContainer).Text(model.WeaponSkill).FontSize(fontSize);
                    table.Cell().Row(rowNumber).Column(5).Element(UnitContainer).Text(model.BallisticSkill).FontSize(fontSize);
                    table.Cell().Row(rowNumber).Column(6).Element(UnitContainer).Text(model.Strength).FontSize(fontSize);
                    table.Cell().Row(rowNumber).Column(7).Element(UnitContainer).Text(model.Toughness).FontSize(fontSize);
                    table.Cell().Row(rowNumber).Column(8).Element(UnitContainer).Text(model.Wounds).FontSize(fontSize);
                    table.Cell().Row(rowNumber).Column(9).Element(UnitContainer).Text(model.Initiative).FontSize(fontSize);
                    table.Cell().Row(rowNumber).Column(10).Element(UnitContainer).Text(model.Attacks).FontSize(fontSize);
                    table.Cell().Row(rowNumber).Column(11).Element(UnitContainer).Text(model.Leadership).FontSize(fontSize);
                    table.Cell().Row(rowNumber).Column(12).Element(UnitContainer).Text($"{model.GetMeleeSaveString()}").FontSize(fontSize);
                    table.Cell().Row(rowNumber).Column(13).Element(UnitContainer).Text($"{model.GetMagicSaveString()}").FontSize(fontSize);
                }

                static void PrintUnitRules(TableDescriptor table, float fontSize, uint rowNumber, TowUnit unit)
                {
                    //table.Cell().Row(rowNumber).Column(1).Element(UnitContainer).Text(model.ChampionName).FontSize(fontSize);
                    //table.Cell().Row(rowNumber).Column(2).Element(UnitContainer).Text("1").FontSize(fontSize);
                    table.Cell().Row(rowNumber).Column(2).ColumnSpan(14).Element(UnitContainer).Text(unit.GetRulesShortDescription()).FontSize(fontSize);
                    //table.Cell().Row(rowNumber).Column(3).Element(UnitContainer).Text(model.Movement).FontSize(fontSize);
                    //table.Cell().Row(rowNumber).Column(4).Element(UnitContainer).Text(model.WeaponSkill).FontSize(fontSize);
                    //table.Cell().Row(rowNumber).Column(5).Element(UnitContainer).Text(model.BallisticSkill).FontSize(fontSize);
                    //table.Cell().Row(rowNumber).Column(6).Element(UnitContainer).Text(model.Strength).FontSize(fontSize);
                    //table.Cell().Row(rowNumber).Column(7).Element(UnitContainer).Text(model.Toughness).FontSize(fontSize);
                    //table.Cell().Row(rowNumber).Column(8).Element(UnitContainer).Text(model.Wounds).FontSize(fontSize);
                    //table.Cell().Row(rowNumber).Column(9).Element(UnitContainer).Text(model.Initiative).FontSize(fontSize);
                    //table.Cell().Row(rowNumber).Column(10).Element(UnitContainer).Text(model.Attacks).FontSize(fontSize);
                    //table.Cell().Row(rowNumber).Column(11).Element(UnitContainer).Text(model.Leadership).FontSize(fontSize);
                    //table.Cell().Row(rowNumber).Column(12).Element(UnitContainer).Text($"{model.GetMeleeSave()}/{model.GetRangedSave()}").FontSize(fontSize);
                    //table.Cell().Row(rowNumber).Column(13).Element(UnitContainer).Text($"{model.GetMagicMeleeSave()}/{model.GetRangedSave()}").FontSize(fontSize);
                }

                static void PrintChampionModelRow(TableDescriptor table, float fontSize, uint rowNumber, TowModel model)
                {
                    table.Cell().Row(rowNumber).Column(1).Element(UnitContainer).Text(model.ChampionName).FontSize(fontSize).Italic();
                    table.Cell().Row(rowNumber).Column(2).Element(UnitContainer).Text("1").FontSize(fontSize);
                    table.Cell().Row(rowNumber).Column(3).Element(UnitContainer).Text(model.Movement).FontSize(fontSize);
                    table.Cell().Row(rowNumber).Column(4).Element(UnitContainer).Text(model.WeaponSkill).FontSize(fontSize);
                    table.Cell().Row(rowNumber).Column(5).Element(UnitContainer).Text(model.BallisticSkill).FontSize(fontSize);
                    table.Cell().Row(rowNumber).Column(6).Element(UnitContainer).Text(model.Strength).FontSize(fontSize);
                    table.Cell().Row(rowNumber).Column(7).Element(UnitContainer).Text(model.Toughness).FontSize(fontSize);
                    table.Cell().Row(rowNumber).Column(8).Element(UnitContainer).Text(model.Wounds).FontSize(fontSize);
                    table.Cell().Row(rowNumber).Column(9).Element(UnitContainer).Text(model.Initiative).FontSize(fontSize);
                    table.Cell().Row(rowNumber).Column(10).Element(UnitContainer).Text(model.Attacks).FontSize(fontSize);
                    table.Cell().Row(rowNumber).Column(11).Element(UnitContainer).Text(model.Leadership).FontSize(fontSize);
                    table.Cell().Row(rowNumber).Column(12).Element(UnitContainer).Text($"{model.GetMeleeSaveString()}").FontSize(fontSize);
                    table.Cell().Row(rowNumber).Column(13).Element(UnitContainer).Text($"{model.GetMagicSaveString()}").FontSize(fontSize);

                    table.Cell().Row(rowNumber).Column(15).Element(UnitContainer).Text($"{model.PointCost}").FontSize(fontSize).Italic();
                }

                static void PrintMagicBannerRow(TableDescriptor table, float fontSize, uint rowNumber, TowMagicBanner banner)
                {
                    table.Cell().Row(rowNumber).Column(1).Element(UnitContainer).Text(banner.MagicItemType.ToString()).FontSize(fontSize).Italic();
                    table.Cell().Row(rowNumber).Column(2).ColumnSpan(13).Element(UnitContainer).Text(banner.GetMagicItemRulesShortDescription()).FontSize(fontSize);
                    table.Cell().Row(rowNumber).Column(15).Element(UnitContainer).Text($"{banner.Points}").FontSize(fontSize).Italic();
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
        .ShowInCompanion();

    }


    static IContainer Block(IContainer container)
    {
        return container
            .Border(1)
            .Background(Colors.Grey.Lighten2)
            .ShowOnce()
            //.MinWidth(50)
            //.MinHeight(50)
            .AlignCenter()
            .AlignMiddle();
    }

    static IContainer UnitContainer(IContainer container)
    {
        return container
            .Border(1)
            .Background(Colors.Grey.Lighten4)
            .ShowOnce()
            //.MinWidth(50)
            //.MinHeight(50)
            .AlignCenter()
            .AlignMiddle();
    }

    static IContainer UnitName(IContainer container)
    {
        return container
            .Border(1)
            .Background(Colors.Grey.Lighten4)
            .ShowOnce()
            //.MinWidth(50)
            //.MinHeight(50)
            .AlignLeft()
            .AlignMiddle();
    }

    static IContainer UnitCommandGroupMember(IContainer container)
    {
        return container
            .Border(0)
            .Background(Colors.Grey.Lighten5)
            .ShowOnce()
            //.MinWidth(50)
            //.MinHeight(50)
            .AlignCenter()
            .AlignMiddle();
    }

}
