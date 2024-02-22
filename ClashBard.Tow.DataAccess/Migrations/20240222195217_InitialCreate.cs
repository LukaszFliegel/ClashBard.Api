using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClashBard.Tow.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WarhammerFactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarhammerFactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarhammerModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Movement = table.Column<int>(type: "int", nullable: false),
                    WeaponSkill = table.Column<int>(type: "int", nullable: false),
                    BallisticSkill = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Toughness = table.Column<int>(type: "int", nullable: false),
                    Wounds = table.Column<int>(type: "int", nullable: false),
                    Initiative = table.Column<int>(type: "int", nullable: false),
                    Attacks = table.Column<int>(type: "int", nullable: false),
                    Leadership = table.Column<int>(type: "int", nullable: false),
                    WarhammerFactionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarhammerModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarhammerModels_WarhammerFactions_WarhammerFactionId",
                        column: x => x.WarhammerFactionId,
                        principalTable: "WarhammerFactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WarhammerModels_WarhammerFactionId",
                table: "WarhammerModels",
                column: "WarhammerFactionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WarhammerModels");

            migrationBuilder.DropTable(
                name: "WarhammerFactions");
        }
    }
}
