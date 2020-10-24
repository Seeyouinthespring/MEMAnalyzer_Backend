using Microsoft.EntityFrameworkCore.Migrations;

namespace MEMAnalyzer_Backend.Migrations
{
    public partial class AddResultsTable2410 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    DeviceInfo = table.Column<string>(nullable: true),
                    CategoryOnePercentage = table.Column<double>(nullable: false),
                    CategorytwoPercentage = table.Column<double>(nullable: false),
                    CategoryThreePercentage = table.Column<double>(nullable: false),
                    CategoryFourPercentage = table.Column<double>(nullable: false),
                    CategoryFivePercentage = table.Column<double>(nullable: false),
                    CategorySixPercentage = table.Column<double>(nullable: false),
                    CategorySevenPercentage = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Results_UserId",
                table: "Results",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Results");
        }
    }
}
