using Microsoft.EntityFrameworkCore.Migrations;

namespace AssignmentApp.Core.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    MatchDate = table.Column<string>(nullable: true),
                    MatchTime = table.Column<string>(nullable: true),
                    TeamA = table.Column<string>(nullable: true),
                    TeamB = table.Column<string>(nullable: true),
                    Sport = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MatchOdds",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Specifier = table.Column<string>(nullable: true),
                    Odd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MatchID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchOdds", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MatchOdds_Matches_MatchID",
                        column: x => x.MatchID,
                        principalTable: "Matches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "ID", "Description", "MatchDate", "MatchTime", "Sport", "TeamA", "TeamB" },
                values: new object[] { 1L, "OSFP-PAO", "12/05/2022", "12:00", 1, "OSFP", "PAO" });

            migrationBuilder.InsertData(
                table: "MatchOdds",
                columns: new[] { "ID", "MatchID", "Odd", "Specifier" },
                values: new object[] { 1L, 1L, 1.5m, "X" });

            migrationBuilder.CreateIndex(
                name: "IX_MatchOdds_MatchID",
                table: "MatchOdds",
                column: "MatchID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchOdds");

            migrationBuilder.DropTable(
                name: "Matches");
        }
    }
}
