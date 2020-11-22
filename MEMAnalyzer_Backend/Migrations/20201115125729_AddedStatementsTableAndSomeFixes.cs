using Microsoft.EntityFrameworkCore.Migrations;

namespace MEMAnalyzer_Backend.Migrations
{
    public partial class AddedStatementsTableAndSomeFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategorySevenPercentage",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "CategorySixPercentage",
                table: "Results");

            migrationBuilder.AddColumn<long>(
                name: "StatementId",
                table: "Results",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Statements",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficialCode = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statements", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Results_StatementId",
                table: "Results",
                column: "StatementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Statements_StatementId",
                table: "Results",
                column: "StatementId",
                principalTable: "Statements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Statements_StatementId",
                table: "Results");

            migrationBuilder.DropTable(
                name: "Statements");

            migrationBuilder.DropIndex(
                name: "IX_Results_StatementId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "StatementId",
                table: "Results");

            migrationBuilder.AddColumn<double>(
                name: "CategorySevenPercentage",
                table: "Results",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CategorySixPercentage",
                table: "Results",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
