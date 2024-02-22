using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashBard.Tow.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SpecialRules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WarhammerModels_WarhammerFactions_WarhammerFactionId",
                table: "WarhammerModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WarhammerModels",
                table: "WarhammerModels");

            migrationBuilder.RenameTable(
                name: "WarhammerModels",
                newName: "TowModels");

            migrationBuilder.RenameColumn(
                name: "WarhammerFactionId",
                table: "TowModels",
                newName: "FactionId");

            migrationBuilder.RenameIndex(
                name: "IX_WarhammerModels_WarhammerFactionId",
                table: "TowModels",
                newName: "IX_TowModels_FactionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TowModels",
                table: "TowModels",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TowModelSpecialRule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LongDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TowModelSpecialRule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TowModelTowModelSpecialRule",
                columns: table => new
                {
                    SpecialRulesId = table.Column<int>(type: "int", nullable: false),
                    TowModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TowModelTowModelSpecialRule", x => new { x.SpecialRulesId, x.TowModelId });
                    table.ForeignKey(
                        name: "FK_TowModelTowModelSpecialRule_TowModelSpecialRule_SpecialRulesId",
                        column: x => x.SpecialRulesId,
                        principalTable: "TowModelSpecialRule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TowModelTowModelSpecialRule_TowModels_TowModelId",
                        column: x => x.TowModelId,
                        principalTable: "TowModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "WarhammerFactions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Empire of Man" },
                    { 2, "Orc & Goblin Tribes" },
                    { 3, "Dwarfen Mountain Holds" },
                    { 4, "Warriors of Chaos" },
                    { 5, "Kingdom of Bretonnia" },
                    { 6, "Beastmen Brayherds" },
                    { 7, "Wood Elf Realms" },
                    { 8, "Tomb Kings of Khemri" },
                    { 9, "High Elf Realms" },
                    { 10, "Dark Elves" },
                    { 11, "Skaven" },
                    { 12, "Vampire Counts" },
                    { 13, "Daemons of Chaos" },
                    { 14, "Ogre Kingdoms" },
                    { 15, "Lizardmen" },
                    { 16, "Chaos Dwarfs" }
                });

            migrationBuilder.InsertData(
                table: "TowModels",
                columns: new[] { "Id", "Attacks", "BallisticSkill", "FactionId", "Initiative", "Leadership", "Movement", "Name", "Strength", "Toughness", "WeaponSkill", "Wounds" },
                values: new object[,]
                {
                    { 1, 4, 7, 10, 6, 10, 5, "Dark Elf Dreadlord", 4, 3, 7, 3 },
                    { 2, 3, 6, 10, 5, 9, 5, "Dark Elf Master", 4, 3, 6, 2 },
                    { 3, 2, 4, 10, 5, 8, 5, "Supreme Sorceress", 3, 3, 4, 3 },
                    { 4, 1, 4, 10, 4, 8, 5, "Sorceress", 3, 3, 4, 2 },
                    { 5, 3, 7, 10, 5, 9, 5, "High Beastmaster", 4, 3, 7, 3 },
                    { 6, 3, 6, 10, 7, 8, 5, "Death Hag", 4, 3, 6, 2 },
                    { 7, 3, 7, 10, 7, 8, 5, "Khainite Assassin", 4, 3, 8, 2 },
                    { 8, 1, 4, 10, 4, 8, 5, "Dark Elf Warrior", 3, 3, 4, 1 },
                    { 9, 1, 4, 10, 4, 8, 5, "Repeater Crossbowman", 3, 3, 4, 1 },
                    { 10, 1, 0, 10, 2, 6, 5, "Black Guard of Naggarond", 4, 3, 3, 2 },
                    { 11, 0, 0, 10, 0, 0, 2, "Scourgerunner Chariot", 0, 6, 0, 2 },
                    { 12, 1, 4, 10, 4, 8, 5, "Beastmaster Crew", 3, 3, 4, 1 },
                    { 13, 1, 0, 10, 4, 0, 9, "Dark Steed", 3, 3, 3, 1 },
                    { 14, 0, 0, 10, 0, 0, 2, "Cold One Chariot", 0, 5, 0, 4 },
                    { 15, 1, 4, 10, 5, 9, 5, "Knight Charioteer", 4, 3, 5, 1 },
                    { 16, 2, 0, 10, 2, 0, 7, "Cold One", 4, 3, 3, 1 },
                    { 17, 5, 0, 10, 3, 7, 6, "Black Dragon", 7, 3, 6, 6 },
                    { 18, 5, 0, 10, 3, 7, 6, "Manticore", 5, 1, 5, 4 },
                    { 19, 2, 0, 10, 3, 6, 6, "War Hydra", 5, 5, 4, 5 },
                    { 20, 1, 4, 10, 4, 8, 6, "Beastmaster Handlers", 3, 3, 4, 2 },
                    { 21, 3, 5, 10, 5, 7, 7, "Bloodwrack Medusa", 4, 4, 5, 4 },
                    { 22, 5, 0, 10, 3, 6, 6, "Kharibdyss", 7, 5, 5, 5 },
                    { 23, 0, 0, 10, 0, 0, 0, "Repeater Bolt Thrower", 0, 6, 0, 2 },
                    { 24, 2, 4, 10, 4, 8, 5, "Dark Elf Crew", 3, 3, 4, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TowModelTowModelSpecialRule_TowModelId",
                table: "TowModelTowModelSpecialRule",
                column: "TowModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_TowModels_WarhammerFactions_FactionId",
                table: "TowModels",
                column: "FactionId",
                principalTable: "WarhammerFactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TowModels_WarhammerFactions_FactionId",
                table: "TowModels");

            migrationBuilder.DropTable(
                name: "TowModelTowModelSpecialRule");

            migrationBuilder.DropTable(
                name: "TowModelSpecialRule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TowModels",
                table: "TowModels");

            migrationBuilder.DeleteData(
                table: "TowModels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TowModels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TowModels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TowModels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TowModels",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TowModels",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TowModels",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TowModels",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TowModels",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TowModels",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TowModels",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TowModels",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TowModels",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TowModels",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TowModels",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TowModels",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TowModels",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TowModels",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TowModels",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TowModels",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TowModels",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TowModels",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TowModels",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TowModels",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "WarhammerFactions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WarhammerFactions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WarhammerFactions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WarhammerFactions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WarhammerFactions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WarhammerFactions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "WarhammerFactions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "WarhammerFactions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "WarhammerFactions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "WarhammerFactions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "WarhammerFactions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "WarhammerFactions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "WarhammerFactions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "WarhammerFactions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "WarhammerFactions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "WarhammerFactions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.RenameTable(
                name: "TowModels",
                newName: "WarhammerModels");

            migrationBuilder.RenameColumn(
                name: "FactionId",
                table: "WarhammerModels",
                newName: "WarhammerFactionId");

            migrationBuilder.RenameIndex(
                name: "IX_TowModels_FactionId",
                table: "WarhammerModels",
                newName: "IX_WarhammerModels_WarhammerFactionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WarhammerModels",
                table: "WarhammerModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WarhammerModels_WarhammerFactions_WarhammerFactionId",
                table: "WarhammerModels",
                column: "WarhammerFactionId",
                principalTable: "WarhammerFactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
