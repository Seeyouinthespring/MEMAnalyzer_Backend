using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MEMAnalyzer_Backend.Migrations
{
    public partial class AddedDateFieldToResultTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Statements_StatementId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "DeviceInfo",
                table: "Results");

            migrationBuilder.AlterColumn<long>(
                name: "StatementId",
                table: "Results",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Results",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Statements_StatementId",
                table: "Results",
                column: "StatementId",
                principalTable: "Statements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Statements_StatementId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Results");

            migrationBuilder.AlterColumn<long>(
                name: "StatementId",
                table: "Results",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<string>(
                name: "DeviceInfo",
                table: "Results",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Statements_StatementId",
                table: "Results",
                column: "StatementId",
                principalTable: "Statements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
